using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppilar.Api.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Images_CoverImageId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CoverImageId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CoverImageId",
                schema: "public",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoverImageId",
                schema: "public",
                table: "Events",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CoverImageId",
                schema: "public",
                table: "Events",
                column: "CoverImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Images_CoverImageId",
                schema: "public",
                table: "Events",
                column: "CoverImageId",
                principalSchema: "public",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
