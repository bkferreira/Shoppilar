using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppilar.Auth.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                schema: "ident",
                table: "users",
                newName: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                schema: "ident",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_PhoneNumber",
                schema: "ident",
                table: "users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_UserName",
                schema: "ident",
                table: "users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                schema: "ident",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_PhoneNumber",
                schema: "ident",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserName",
                schema: "ident",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "ident",
                table: "users",
                newName: "FullName");
        }
    }
}
