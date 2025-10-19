using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shoppilar.Api.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "AdTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxImageCount = table.Column<int>(type: "integer", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxImageCount = table.Column<int>(type: "integer", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxImageCount = table.Column<int>(type: "integer", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Uf = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    IbgeCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdSubTypes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdSubTypes_AdTypes_AdTypeId",
                        column: x => x.AdTypeId,
                        principalSchema: "public",
                        principalTable: "AdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IbgeCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "public",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdFeatureds",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdFeatureds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdLikes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdPromotions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdPromotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Contact = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ViewsCount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Promotion = table.Column<bool>(type: "boolean", nullable: false),
                    Donation = table.Column<bool>(type: "boolean", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdSubTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_AdSubTypes_AdSubTypeId",
                        column: x => x.AdSubTypeId,
                        principalSchema: "public",
                        principalTable: "AdSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_AdTypes_AdTypeId",
                        column: x => x.AdTypeId,
                        principalSchema: "public",
                        principalTable: "AdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Contact = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExternalUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoverImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "public",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalSchema: "public",
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_TargetTypes_TargetTypeId",
                        column: x => x.TargetTypeId,
                        principalSchema: "public",
                        principalTable: "TargetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_TargetTypes_TargetTypeId",
                        column: x => x.TargetTypeId,
                        principalSchema: "public",
                        principalTable: "TargetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    FileName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContainerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ImageTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    AdId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobId = table.Column<Guid>(type: "uuid", nullable: true),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Ads_AdId",
                        column: x => x.AdId,
                        principalSchema: "public",
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "public",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_ImageTypes_ImageTypeId",
                        column: x => x.ImageTypeId,
                        principalSchema: "public",
                        principalTable: "ImageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PersonTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "public",
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Persons_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalSchema: "public",
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Contact = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    JobTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "public",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalSchema: "public",
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occurrences",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ResolutionComment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Resolved = table.Column<bool>(type: "boolean", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TargetTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportedById = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrenceTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occurrences_OccurrenceTypes_OccurrenceTypeId",
                        column: x => x.OccurrenceTypeId,
                        principalSchema: "public",
                        principalTable: "OccurrenceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Occurrences_Persons_ReportedById",
                        column: x => x.ReportedById,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occurrences_TargetTypes_TargetTypeId",
                        column: x => x.TargetTypeId,
                        principalSchema: "public",
                        principalTable: "TargetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddresses",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Neighborhood = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Complement = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Standard = table.Column<bool>(type: "boolean", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "public",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAddresses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonContacts",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactValue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Standard = table.Column<bool>(type: "boolean", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContacts_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "public",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDocuments",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Validate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Standard = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDocuments_CategoryTypes_CategoryTypeId",
                        column: x => x.CategoryTypeId,
                        principalSchema: "public",
                        principalTable: "CategoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDocuments_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "public",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDocuments_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonFollowers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowedId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFollowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFollowers_Persons_FollowedId",
                        column: x => x.FollowedId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFollowers_Persons_FollowerId",
                        column: x => x.FollowerId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSearchHistories",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Query = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    SearchedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSearchHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonSearchHistories_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSocialMedias",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialMediaTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonSocialMedias_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "public",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSocialMedias_SocialMediaTypes_SocialMediaTypeId",
                        column: x => x.SocialMediaTypeId,
                        principalSchema: "public",
                        principalTable: "SocialMediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdFeatureds_AdId",
                schema: "public",
                table: "AdFeatureds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdFeatureds_Cod",
                schema: "public",
                table: "AdFeatureds",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdFeatureds_ExpirationDate",
                schema: "public",
                table: "AdFeatureds",
                column: "ExpirationDate");

            migrationBuilder.CreateIndex(
                name: "IX_AdLikes_AdId_PersonId",
                schema: "public",
                table: "AdLikes",
                columns: new[] { "AdId", "PersonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdLikes_Cod",
                schema: "public",
                table: "AdLikes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdLikes_PersonId",
                schema: "public",
                table: "AdLikes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AdPromotions_AdId",
                schema: "public",
                table: "AdPromotions",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdPromotions_Cod",
                schema: "public",
                table: "AdPromotions",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdPromotions_ExpirationDate",
                schema: "public",
                table: "AdPromotions",
                column: "ExpirationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AdSubTypeId",
                schema: "public",
                table: "Ads",
                column: "AdSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AdTypeId",
                schema: "public",
                table: "Ads",
                column: "AdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CityId",
                schema: "public",
                table: "Ads",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_Cod",
                schema: "public",
                table: "Ads",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_PersonId",
                schema: "public",
                table: "Ads",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_Price",
                schema: "public",
                table: "Ads",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_Title",
                schema: "public",
                table: "Ads",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_AdSubTypes_AdTypeId",
                schema: "public",
                table: "AdSubTypes",
                column: "AdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdSubTypes_Cod",
                schema: "public",
                table: "AdSubTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdSubTypes_Description",
                schema: "public",
                table: "AdSubTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdTypes_Cod",
                schema: "public",
                table: "AdTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdTypes_Description",
                schema: "public",
                table: "AdTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypes_Cod",
                schema: "public",
                table: "CategoryTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypes_Description",
                schema: "public",
                table: "CategoryTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Cod",
                schema: "public",
                table: "Cities",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IbgeCode",
                schema: "public",
                table: "Cities",
                column: "IbgeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                schema: "public",
                table: "Cities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                schema: "public",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_Cod",
                schema: "public",
                table: "ContactTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_Description",
                schema: "public",
                table: "ContactTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_Cod",
                schema: "public",
                table: "DocumentTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_Description",
                schema: "public",
                table: "DocumentTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CityId",
                schema: "public",
                table: "Events",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Cod",
                schema: "public",
                table: "Events",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ContactTypeId",
                schema: "public",
                table: "Events",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CoverImageId",
                schema: "public",
                table: "Events",
                column: "CoverImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                schema: "public",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PersonId",
                schema: "public",
                table: "Events",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_Cod",
                schema: "public",
                table: "EventTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_Description",
                schema: "public",
                table: "EventTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Cod",
                schema: "public",
                table: "Favorites",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PersonId_TargetId_TargetTypeId",
                schema: "public",
                table: "Favorites",
                columns: new[] { "PersonId", "TargetId", "TargetTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_TargetTypeId",
                schema: "public",
                table: "Favorites",
                column: "TargetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Cod",
                schema: "public",
                table: "Feedbacks",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PersonId_TargetId_TargetTypeId",
                schema: "public",
                table: "Feedbacks",
                columns: new[] { "PersonId", "TargetId", "TargetTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TargetTypeId",
                schema: "public",
                table: "Feedbacks",
                column: "TargetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdId",
                schema: "public",
                table: "Images",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Cod",
                schema: "public",
                table: "Images",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventId",
                schema: "public",
                table: "Images",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageTypeId",
                schema: "public",
                table: "Images",
                column: "ImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_JobId",
                schema: "public",
                table: "Images",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PersonId",
                schema: "public",
                table: "Images",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_Cod",
                schema: "public",
                table: "ImageTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_Description",
                schema: "public",
                table: "ImageTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Cod",
                schema: "public",
                table: "Jobs",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContactTypeId",
                schema: "public",
                table: "Jobs",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTypeId",
                schema: "public",
                table: "Jobs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PersonId",
                schema: "public",
                table: "Jobs",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_Cod",
                schema: "public",
                table: "JobTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_Description",
                schema: "public",
                table: "JobTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occurrences_Cod",
                schema: "public",
                table: "Occurrences",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occurrences_OccurrenceTypeId",
                schema: "public",
                table: "Occurrences",
                column: "OccurrenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrences_ReportedById_TargetId_TargetTypeId",
                schema: "public",
                table: "Occurrences",
                columns: new[] { "ReportedById", "TargetId", "TargetTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occurrences_TargetTypeId",
                schema: "public",
                table: "Occurrences",
                column: "TargetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceTypes_Cod",
                schema: "public",
                table: "OccurrenceTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceTypes_Description",
                schema: "public",
                table: "OccurrenceTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_CityId",
                schema: "public",
                table: "PersonAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_Cod",
                schema: "public",
                table: "PersonAddresses",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_PersonId_Standard",
                schema: "public",
                table: "PersonAddresses",
                columns: new[] { "PersonId", "Standard" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_ZipCode",
                schema: "public",
                table: "PersonAddresses",
                column: "ZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_Cod",
                schema: "public",
                table: "PersonContacts",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_ContactTypeId",
                schema: "public",
                table: "PersonContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_ContactValue",
                schema: "public",
                table: "PersonContacts",
                column: "ContactValue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_PersonId_Standard",
                schema: "public",
                table: "PersonContacts",
                columns: new[] { "PersonId", "Standard" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocuments_CategoryTypeId",
                schema: "public",
                table: "PersonDocuments",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocuments_Cod",
                schema: "public",
                table: "PersonDocuments",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocuments_DocumentNumber_DocumentTypeId",
                schema: "public",
                table: "PersonDocuments",
                columns: new[] { "DocumentNumber", "DocumentTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocuments_DocumentTypeId",
                schema: "public",
                table: "PersonDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocuments_PersonId_Standard",
                schema: "public",
                table: "PersonDocuments",
                columns: new[] { "PersonId", "Standard" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonFollowers_Cod",
                schema: "public",
                table: "PersonFollowers",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonFollowers_FollowedId",
                schema: "public",
                table: "PersonFollowers",
                column: "FollowedId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFollowers_FollowerId_FollowedId",
                schema: "public",
                table: "PersonFollowers",
                columns: new[] { "FollowerId", "FollowedId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Cod",
                schema: "public",
                table: "Persons",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ImageId",
                schema: "public",
                table: "Persons",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Name_Birth",
                schema: "public",
                table: "Persons",
                columns: new[] { "Name", "Birth" });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                schema: "public",
                table: "Persons",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSearchHistories_Cod",
                schema: "public",
                table: "PersonSearchHistories",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonSearchHistories_PersonId",
                schema: "public",
                table: "PersonSearchHistories",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialMedias_Cod",
                schema: "public",
                table: "PersonSocialMedias",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialMedias_PersonId_SocialMediaTypeId",
                schema: "public",
                table: "PersonSocialMedias",
                columns: new[] { "PersonId", "SocialMediaTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonSocialMedias_SocialMediaTypeId",
                schema: "public",
                table: "PersonSocialMedias",
                column: "SocialMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_Cod",
                schema: "public",
                table: "PersonTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_Description",
                schema: "public",
                table: "PersonTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaTypes_Cod",
                schema: "public",
                table: "SocialMediaTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaTypes_Description",
                schema: "public",
                table: "SocialMediaTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_Cod",
                schema: "public",
                table: "States",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_IbgeCode",
                schema: "public",
                table: "States",
                column: "IbgeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_Name",
                schema: "public",
                table: "States",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_States_Uf",
                schema: "public",
                table: "States",
                column: "Uf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetTypes_Cod",
                schema: "public",
                table: "TargetTypes",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetTypes_Description",
                schema: "public",
                table: "TargetTypes",
                column: "Description",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdFeatureds_Ads_AdId",
                schema: "public",
                table: "AdFeatureds",
                column: "AdId",
                principalSchema: "public",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdLikes_Ads_AdId",
                schema: "public",
                table: "AdLikes",
                column: "AdId",
                principalSchema: "public",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdLikes_Persons_PersonId",
                schema: "public",
                table: "AdLikes",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdPromotions_Ads_AdId",
                schema: "public",
                table: "AdPromotions",
                column: "AdId",
                principalSchema: "public",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Persons_PersonId",
                schema: "public",
                table: "Ads",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Images_CoverImageId",
                schema: "public",
                table: "Events",
                column: "CoverImageId",
                principalSchema: "public",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Persons_PersonId",
                schema: "public",
                table: "Events",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Persons_PersonId",
                schema: "public",
                table: "Favorites",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Persons_PersonId",
                schema: "public",
                table: "Feedbacks",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Jobs_JobId",
                schema: "public",
                table: "Images",
                column: "JobId",
                principalSchema: "public",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Persons_PersonId",
                schema: "public",
                table: "Images",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdId",
                schema: "public",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Persons_PersonId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Persons_PersonId",
                schema: "public",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Persons_PersonId",
                schema: "public",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Cities_CityId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_ContactTypes_ContactTypeId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_ContactTypes_ContactTypeId",
                schema: "public",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Images_CoverImageId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropTable(
                name: "AdFeatureds",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AdLikes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AdPromotions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Favorites",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Feedbacks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Occurrences",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonAddresses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonContacts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonDocuments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonFollowers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonSearchHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonSocialMedias",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OccurrenceTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TargetTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CategoryTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SocialMediaTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Ads",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AdSubTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AdTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PersonTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "States",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "EventTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ImageTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "JobTypes",
                schema: "public");
        }
    }
}
