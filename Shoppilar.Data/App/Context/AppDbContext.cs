using Microsoft.EntityFrameworkCore;
using Shoppilar.Data.App.Extensions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public bool HardDeleting { get; set; }

    #region Activity

    public DbSet<Event> Events { get; set; }
    public DbSet<Job> Jobs { get; set; }

    #endregion

    #region Advertisement

    public DbSet<Ad> Ads { get; set; }
    public DbSet<AdFeatured> AdFeatureds { get; set; }
    public DbSet<AdLike> AdLikes { get; set; }
    public DbSet<AdPromotion> AdPromotions { get; set; }

    #endregion

    #region Interaction

    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    #endregion

    #region Location

    public DbSet<City> Cities { get; set; }
    public DbSet<State> States { get; set; }

    #endregion

    #region Media

    public DbSet<Image> Images { get; set; }

    #endregion

    # region Person

    public DbSet<PersonAddress> PersonAddresses { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonContact> PersonContacts { get; set; }
    public DbSet<PersonDocument> PersonDocuments { get; set; }
    public DbSet<PersonFollower> PersonFollowers { get; set; }
    public DbSet<PersonSearchHistory> PersonSearchHistories { get; set; }
    public DbSet<PersonSocialMedia> PersonSocialMedias { get; set; }

    #endregion

    #region Report

    public DbSet<Occurrence> Occurrences { get; set; }

    #endregion

    #region Type

    public DbSet<AdSubType> AdSubTypes { get; set; }
    public DbSet<AdType> AdTypes { get; set; }
    public DbSet<CategoryType> CategoryTypes { get; set; }
    public DbSet<ContactType> ContactTypes { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<ImageType> ImageTypes { get; set; }
    public DbSet<JobType> JobTypes { get; set; }
    public DbSet<OccurrenceType> OccurrenceTypes { get; set; }
    public DbSet<PersonType> PersonTypes { get; set; }
    public DbSet<SocialMediaType> SocialMediaTypes { get; set; }
    public DbSet<TargetType> TargetTypes { get; set; }

    #endregion

    //TODO : Pensa sobre notificacao
    //TODO : Pensa sobre curriculo
    //TODO : Pensa sobre casas aluguel e compra

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ConfigureValidation();
        modelBuilder.ConfigureEntityCod();
        modelBuilder.ConfigureSoftDelete();
    }
}