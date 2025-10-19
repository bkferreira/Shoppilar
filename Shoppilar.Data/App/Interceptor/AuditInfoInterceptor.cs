using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shoppilar.Data.App.Context;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Interceptor
{
    public class AuditInfoInterceptor(IHttpContextAccessor httpContextAccessor) : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            // Se o contexto for nulo, apenas segue o fluxo normal
            var context = eventData.Context;

            if (context is null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            if (context is AppDbContext { HardDeleting: true })
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            // Obtém o contexto HTTP atual (pode ser nulo em jobs/background tasks)
            var httpContext = httpContextAccessor.HttpContext;

            // Tenta identificar o usuário autenticado
            var PersonId = TryGetPersonId(httpContext);

            // Pega todas as entidades rastreadas que herdam de EntityBase e estão sendo alteradas
            var entries = context.ChangeTracker.Entries<EntityBase>()
                .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted)
                .ToList();

            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedById ??= PersonId;
                        entry.Entity.IsActive = true;
                        entry.Entity.IsDeleted = false;
                        entry.Entity.Version = 1;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = utcNow;
                        entry.Entity.UpdatedById = PersonId;
                        entry.Entity.Version = (entry.Entity.Version == 0 ? 1 : entry.Entity.Version + 1);
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.IsActive = false;
                        entry.Entity.DeletedAt = utcNow;
                        entry.Entity.DeletedById = PersonId;
                        break;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static Guid? TryGetPersonId(HttpContext? httpContext)
        {
            if (httpContext?.User.Identity?.IsAuthenticated != true)
                return null;

            var claimValue = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(claimValue, out var PersonId) ? PersonId : null;
        }
    }
}