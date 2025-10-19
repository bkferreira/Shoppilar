using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppilar.Api.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdFeatureds_Ads_AdId",
                schema: "public",
                table: "AdFeatureds");

            migrationBuilder.DropForeignKey(
                name: "FK_AdLikes_Ads_AdId",
                schema: "public",
                table: "AdLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_AdLikes_Persons_PersonId",
                schema: "public",
                table: "AdLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_AdPromotions_Ads_AdId",
                schema: "public",
                table: "AdPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdSubTypes_AdSubTypeId",
                schema: "public",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdTypes_AdTypeId",
                schema: "public",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Cities_CityId",
                schema: "public",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Persons_PersonId",
                schema: "public",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_AdSubTypes_AdTypes_AdTypeId",
                schema: "public",
                table: "AdSubTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                schema: "public",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Cities_CityId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_ContactTypes_ContactTypeId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Persons_PersonId",
                schema: "public",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Persons_PersonId",
                schema: "public",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_TargetTypes_TargetTypeId",
                schema: "public",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Persons_PersonId",
                schema: "public",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_TargetTypes_TargetTypeId",
                schema: "public",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ads_AdId",
                schema: "public",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventId",
                schema: "public",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_ImageTypes_ImageTypeId",
                schema: "public",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Jobs_JobId",
                schema: "public",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Persons_PersonId",
                schema: "public",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_ContactTypes_ContactTypeId",
                schema: "public",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                schema: "public",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Persons_PersonId",
                schema: "public",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Occurrences_OccurrenceTypes_OccurrenceTypeId",
                schema: "public",
                table: "Occurrences");

            migrationBuilder.DropForeignKey(
                name: "FK_Occurrences_Persons_ReportedById",
                schema: "public",
                table: "Occurrences");

            migrationBuilder.DropForeignKey(
                name: "FK_Occurrences_TargetTypes_TargetTypeId",
                schema: "public",
                table: "Occurrences");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonAddresses_Cities_CityId",
                schema: "public",
                table: "PersonAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonAddresses_Persons_PersonId",
                schema: "public",
                table: "PersonAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonContacts_ContactTypes_ContactTypeId",
                schema: "public",
                table: "PersonContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonContacts_Persons_PersonId",
                schema: "public",
                table: "PersonContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDocuments_CategoryTypes_CategoryTypeId",
                schema: "public",
                table: "PersonDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDocuments_DocumentTypes_DocumentTypeId",
                schema: "public",
                table: "PersonDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDocuments_Persons_PersonId",
                schema: "public",
                table: "PersonDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonFollowers_Persons_FollowedId",
                schema: "public",
                table: "PersonFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonFollowers_Persons_FollowerId",
                schema: "public",
                table: "PersonFollowers");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Images_ImageId",
                schema: "public",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                schema: "public",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSearchHistories_Persons_PersonId",
                schema: "public",
                table: "PersonSearchHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSocialMedias_Persons_PersonId",
                schema: "public",
                table: "PersonSocialMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSocialMedias_SocialMediaTypes_SocialMediaTypeId",
                schema: "public",
                table: "PersonSocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                schema: "public",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                schema: "public",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occurrences",
                schema: "public",
                table: "Occurrences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                schema: "public",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                schema: "public",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                schema: "public",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                schema: "public",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                schema: "public",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                schema: "public",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                schema: "public",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TargetTypes",
                schema: "public",
                table: "TargetTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMediaTypes",
                schema: "public",
                table: "SocialMediaTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonTypes",
                schema: "public",
                table: "PersonTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSocialMedias",
                schema: "public",
                table: "PersonSocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSearchHistories",
                schema: "public",
                table: "PersonSearchHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonFollowers",
                schema: "public",
                table: "PersonFollowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDocuments",
                schema: "public",
                table: "PersonDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonContacts",
                schema: "public",
                table: "PersonContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonAddresses",
                schema: "public",
                table: "PersonAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OccurrenceTypes",
                schema: "public",
                table: "OccurrenceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTypes",
                schema: "public",
                table: "JobTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageTypes",
                schema: "public",
                table: "ImageTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTypes",
                schema: "public",
                table: "EventTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypes",
                schema: "public",
                table: "DocumentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactTypes",
                schema: "public",
                table: "ContactTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTypes",
                schema: "public",
                table: "CategoryTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdTypes",
                schema: "public",
                table: "AdTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdSubTypes",
                schema: "public",
                table: "AdSubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdPromotions",
                schema: "public",
                table: "AdPromotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdLikes",
                schema: "public",
                table: "AdLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdFeatureds",
                schema: "public",
                table: "AdFeatureds");

            migrationBuilder.RenameTable(
                name: "States",
                schema: "public",
                newName: "states",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Persons",
                schema: "public",
                newName: "persons",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Occurrences",
                schema: "public",
                newName: "occurrences",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Jobs",
                schema: "public",
                newName: "jobs",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Images",
                schema: "public",
                newName: "images",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                schema: "public",
                newName: "feedbacks",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Favorites",
                schema: "public",
                newName: "favorites",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Events",
                schema: "public",
                newName: "events",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "public",
                newName: "cities",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Ads",
                schema: "public",
                newName: "ads",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "TargetTypes",
                schema: "public",
                newName: "target_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "SocialMediaTypes",
                schema: "public",
                newName: "social_media_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PersonTypes",
                schema: "public",
                newName: "person_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PersonSocialMedias",
                schema: "public",
                newName: "person_social_medias",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PersonSearchHistories",
                schema: "public",
                newName: "person_search_histories",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PersonFollowers",
                schema: "public",
                newName: "person_followers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PersonDocuments",
                schema: "public",
                newName: "person_documents",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PersonContacts",
                schema: "public",
                newName: "person_contacts",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PersonAddresses",
                schema: "public",
                newName: "person_addresses",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "OccurrenceTypes",
                schema: "public",
                newName: "occurrence_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "JobTypes",
                schema: "public",
                newName: "job_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ImageTypes",
                schema: "public",
                newName: "image_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "EventTypes",
                schema: "public",
                newName: "event_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "DocumentTypes",
                schema: "public",
                newName: "document_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ContactTypes",
                schema: "public",
                newName: "contact_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "CategoryTypes",
                schema: "public",
                newName: "category_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "AdTypes",
                schema: "public",
                newName: "ad_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "AdSubTypes",
                schema: "public",
                newName: "ad_sub_types",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "AdPromotions",
                schema: "public",
                newName: "ad_promotions",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "AdLikes",
                schema: "public",
                newName: "ad_likes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "AdFeatureds",
                schema: "public",
                newName: "ad_featured",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "states",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Uf",
                schema: "public",
                table: "states",
                newName: "uf");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "states",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "states",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "states",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "states",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "states",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "states",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "states",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "IbgeCode",
                schema: "public",
                table: "states",
                newName: "ibge_code");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "states",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "states",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "states",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "states",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_States_Uf",
                schema: "public",
                table: "states",
                newName: "IX_states_uf");

            migrationBuilder.RenameIndex(
                name: "IX_States_Name",
                schema: "public",
                table: "states",
                newName: "IX_states_name");

            migrationBuilder.RenameIndex(
                name: "IX_States_Cod",
                schema: "public",
                table: "states",
                newName: "IX_states_cod");

            migrationBuilder.RenameIndex(
                name: "IX_States_IbgeCode",
                schema: "public",
                table: "states",
                newName: "IX_states_ibge_code");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "persons",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "persons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "persons",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Birth",
                schema: "public",
                table: "persons",
                newName: "birth");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "persons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "persons",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "persons",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonTypeId",
                schema: "public",
                table: "persons",
                newName: "person_type_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "persons",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "persons",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                schema: "public",
                table: "persons",
                newName: "image_id");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "persons",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "persons",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "persons",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "persons",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_Name_Birth",
                schema: "public",
                table: "persons",
                newName: "IX_persons_name_birth");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_Cod",
                schema: "public",
                table: "persons",
                newName: "IX_persons_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PersonTypeId",
                schema: "public",
                table: "persons",
                newName: "IX_persons_person_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_ImageId",
                schema: "public",
                table: "persons",
                newName: "IX_persons_image_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "occurrences",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Resolved",
                schema: "public",
                table: "occurrences",
                newName: "resolved");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "occurrences",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "occurrences",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "occurrences",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "occurrences",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "occurrences",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TargetTypeId",
                schema: "public",
                table: "occurrences",
                newName: "target_type_id");

            migrationBuilder.RenameColumn(
                name: "TargetId",
                schema: "public",
                table: "occurrences",
                newName: "target_id");

            migrationBuilder.RenameColumn(
                name: "ResolvedAt",
                schema: "public",
                table: "occurrences",
                newName: "resolved_at");

            migrationBuilder.RenameColumn(
                name: "ResolutionComment",
                schema: "public",
                table: "occurrences",
                newName: "resolution_comment");

            migrationBuilder.RenameColumn(
                name: "ReportedById",
                schema: "public",
                table: "occurrences",
                newName: "reported_by_id");

            migrationBuilder.RenameColumn(
                name: "OccurrenceTypeId",
                schema: "public",
                table: "occurrences",
                newName: "occurrence_type_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "occurrences",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "occurrences",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "occurrences",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "occurrences",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "occurrences",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "occurrences",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Occurrences_Cod",
                schema: "public",
                table: "occurrences",
                newName: "IX_occurrences_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Occurrences_TargetTypeId",
                schema: "public",
                table: "occurrences",
                newName: "IX_occurrences_target_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Occurrences_ReportedById_TargetId_TargetTypeId",
                schema: "public",
                table: "occurrences",
                newName: "IX_occurrences_reported_by_id_target_id_target_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Occurrences_OccurrenceTypeId",
                schema: "public",
                table: "occurrences",
                newName: "IX_occurrences_occurrence_type_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "jobs",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Salary",
                schema: "public",
                table: "jobs",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "jobs",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Contact",
                schema: "public",
                table: "jobs",
                newName: "contact");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "jobs",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "jobs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "jobs",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "jobs",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "jobs",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "JobTypeId",
                schema: "public",
                table: "jobs",
                newName: "job_type_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "jobs",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "jobs",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                schema: "public",
                table: "jobs",
                newName: "expiration_date");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "jobs",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "jobs",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "jobs",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "jobs",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ContactTypeId",
                schema: "public",
                table: "jobs",
                newName: "contact_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_Cod",
                schema: "public",
                table: "jobs",
                newName: "IX_jobs_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_PersonId",
                schema: "public",
                table: "jobs",
                newName: "IX_jobs_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_JobTypeId",
                schema: "public",
                table: "jobs",
                newName: "IX_jobs_job_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_ContactTypeId",
                schema: "public",
                table: "jobs",
                newName: "IX_jobs_contact_type_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "images",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "public",
                table: "images",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Size",
                schema: "public",
                table: "images",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "images",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "images",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "images",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "images",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "images",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "JobId",
                schema: "public",
                table: "images",
                newName: "job_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "images",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "images",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ImageTypeId",
                schema: "public",
                table: "images",
                newName: "image_type_id");

            migrationBuilder.RenameColumn(
                name: "FileName",
                schema: "public",
                table: "images",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "EventId",
                schema: "public",
                table: "images",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "images",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "images",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "images",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "images",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                schema: "public",
                table: "images",
                newName: "content_type");

            migrationBuilder.RenameColumn(
                name: "ContainerName",
                schema: "public",
                table: "images",
                newName: "container_name");

            migrationBuilder.RenameColumn(
                name: "AdId",
                schema: "public",
                table: "images",
                newName: "ad_id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Cod",
                schema: "public",
                table: "images",
                newName: "IX_images_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Images_PersonId",
                schema: "public",
                table: "images",
                newName: "IX_images_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_JobId",
                schema: "public",
                table: "images",
                newName: "IX_images_job_id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ImageTypeId",
                schema: "public",
                table: "images",
                newName: "IX_images_image_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_EventId",
                schema: "public",
                table: "images",
                newName: "IX_images_event_id");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AdId",
                schema: "public",
                table: "images",
                newName: "IX_images_ad_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "feedbacks",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Rating",
                schema: "public",
                table: "feedbacks",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Comment",
                schema: "public",
                table: "feedbacks",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "feedbacks",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "feedbacks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "feedbacks",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "feedbacks",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TargetTypeId",
                schema: "public",
                table: "feedbacks",
                newName: "target_type_id");

            migrationBuilder.RenameColumn(
                name: "TargetId",
                schema: "public",
                table: "feedbacks",
                newName: "target_id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "feedbacks",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "feedbacks",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "feedbacks",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "feedbacks",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "feedbacks",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "feedbacks",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "feedbacks",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_Cod",
                schema: "public",
                table: "feedbacks",
                newName: "IX_feedbacks_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_TargetTypeId",
                schema: "public",
                table: "feedbacks",
                newName: "IX_feedbacks_target_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_PersonId_TargetId_TargetTypeId",
                schema: "public",
                table: "feedbacks",
                newName: "IX_feedbacks_person_id_target_id_target_type_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "favorites",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "favorites",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "favorites",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "favorites",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "favorites",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TargetTypeId",
                schema: "public",
                table: "favorites",
                newName: "target_type_id");

            migrationBuilder.RenameColumn(
                name: "TargetId",
                schema: "public",
                table: "favorites",
                newName: "target_id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "favorites",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "favorites",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "favorites",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "favorites",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "favorites",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "favorites",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "favorites",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_Cod",
                schema: "public",
                table: "favorites",
                newName: "IX_favorites_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_TargetTypeId",
                schema: "public",
                table: "favorites",
                newName: "IX_favorites_target_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_PersonId_TargetId_TargetTypeId",
                schema: "public",
                table: "favorites",
                newName: "IX_favorites_person_id_target_id_target_type_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "events",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "public",
                table: "events",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "public",
                table: "events",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "public",
                table: "events",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "events",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Contact",
                schema: "public",
                table: "events",
                newName: "contact");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "events",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "events",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "events",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "events",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                schema: "public",
                table: "events",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "events",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                schema: "public",
                table: "events",
                newName: "is_public");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "events",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "events",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ExternalUrl",
                schema: "public",
                table: "events",
                newName: "external_url");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                schema: "public",
                table: "events",
                newName: "expiration_date");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                schema: "public",
                table: "events",
                newName: "event_type_id");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                schema: "public",
                table: "events",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "events",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "events",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "events",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "events",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ContactTypeId",
                schema: "public",
                table: "events",
                newName: "contact_type_id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "public",
                table: "events",
                newName: "city_id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_Cod",
                schema: "public",
                table: "events",
                newName: "IX_events_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Events_PersonId",
                schema: "public",
                table: "events",
                newName: "IX_events_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_EventTypeId",
                schema: "public",
                table: "events",
                newName: "IX_events_event_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_ContactTypeId",
                schema: "public",
                table: "events",
                newName: "IX_events_contact_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_CityId",
                schema: "public",
                table: "events",
                newName: "IX_events_city_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "cities",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "cities",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "cities",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "cities",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "cities",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "cities",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StateId",
                schema: "public",
                table: "cities",
                newName: "state_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "cities",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "cities",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "IbgeCode",
                schema: "public",
                table: "cities",
                newName: "ibge_code");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "cities",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "cities",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "cities",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "cities",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Name",
                schema: "public",
                table: "cities",
                newName: "IX_cities_name");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Cod",
                schema: "public",
                table: "cities",
                newName: "IX_cities_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_StateId",
                schema: "public",
                table: "cities",
                newName: "IX_cities_state_id");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_IbgeCode",
                schema: "public",
                table: "cities",
                newName: "IX_cities_ibge_code");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "ads",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "public",
                table: "ads",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Promotion",
                schema: "public",
                table: "ads",
                newName: "promotion");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "public",
                table: "ads",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Donation",
                schema: "public",
                table: "ads",
                newName: "donation");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "ads",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Contact",
                schema: "public",
                table: "ads",
                newName: "contact");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "ads",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "ads",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ViewsCount",
                schema: "public",
                table: "ads",
                newName: "views_count");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "ads",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "ads",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "ads",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "ads",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ads",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                schema: "public",
                table: "ads",
                newName: "expiration_date");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "ads",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ads",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "ads",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "ads",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "public",
                table: "ads",
                newName: "city_id");

            migrationBuilder.RenameColumn(
                name: "AdTypeId",
                schema: "public",
                table: "ads",
                newName: "ad_type_id");

            migrationBuilder.RenameColumn(
                name: "AdSubTypeId",
                schema: "public",
                table: "ads",
                newName: "ad_sub_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_Title",
                schema: "public",
                table: "ads",
                newName: "IX_ads_title");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_Price",
                schema: "public",
                table: "ads",
                newName: "IX_ads_price");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_Cod",
                schema: "public",
                table: "ads",
                newName: "IX_ads_cod");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_PersonId",
                schema: "public",
                table: "ads",
                newName: "IX_ads_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_CityId",
                schema: "public",
                table: "ads",
                newName: "IX_ads_city_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_AdTypeId",
                schema: "public",
                table: "ads",
                newName: "IX_ads_ad_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_AdSubTypeId",
                schema: "public",
                table: "ads",
                newName: "IX_ads_ad_sub_type_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "target_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "target_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "target_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "target_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "target_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "target_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "target_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "target_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "target_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "target_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "target_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "target_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "target_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "target_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_TargetTypes_Description",
                schema: "public",
                table: "target_types",
                newName: "IX_target_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_TargetTypes_Cod",
                schema: "public",
                table: "target_types",
                newName: "IX_target_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "social_media_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "social_media_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "social_media_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "social_media_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "social_media_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "social_media_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "social_media_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "social_media_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "social_media_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "social_media_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "social_media_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "social_media_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "social_media_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "social_media_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaTypes_Description",
                schema: "public",
                table: "social_media_types",
                newName: "IX_social_media_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaTypes_Cod",
                schema: "public",
                table: "social_media_types",
                newName: "IX_social_media_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "person_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "person_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "person_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "person_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "person_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "person_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "person_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "person_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "person_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "person_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "person_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "person_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "person_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "person_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PersonTypes_Description",
                schema: "public",
                table: "person_types",
                newName: "IX_person_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_PersonTypes_Cod",
                schema: "public",
                table: "person_types",
                newName: "IX_person_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "person_social_medias",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "person_social_medias",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "person_social_medias",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "person_social_medias",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "person_social_medias",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SocialMediaTypeId",
                schema: "public",
                table: "person_social_medias",
                newName: "social_media_type_id");

            migrationBuilder.RenameColumn(
                name: "ProfileUrl",
                schema: "public",
                table: "person_social_medias",
                newName: "profile_url");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "person_social_medias",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "person_social_medias",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "person_social_medias",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "person_social_medias",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "person_social_medias",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "person_social_medias",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "person_social_medias",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSocialMedias_SocialMediaTypeId",
                schema: "public",
                table: "person_social_medias",
                newName: "IX_person_social_medias_social_media_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSocialMedias_PersonId_SocialMediaTypeId",
                schema: "public",
                table: "person_social_medias",
                newName: "IX_person_social_medias_person_id_social_media_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSocialMedias_Cod",
                schema: "public",
                table: "person_social_medias",
                newName: "IX_person_social_medias_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "person_search_histories",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Query",
                schema: "public",
                table: "person_search_histories",
                newName: "query");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "person_search_histories",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "person_search_histories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "person_search_histories",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "person_search_histories",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SearchedAt",
                schema: "public",
                table: "person_search_histories",
                newName: "searched_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "person_search_histories",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "person_search_histories",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "person_search_histories",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "person_search_histories",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "person_search_histories",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "person_search_histories",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "person_search_histories",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSearchHistories_PersonId",
                schema: "public",
                table: "person_search_histories",
                newName: "IX_person_search_histories_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonSearchHistories_Cod",
                schema: "public",
                table: "person_search_histories",
                newName: "IX_person_search_histories_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "person_followers",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "person_followers",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "person_followers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "person_followers",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "person_followers",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "person_followers",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "person_followers",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                schema: "public",
                table: "person_followers",
                newName: "follower_id");

            migrationBuilder.RenameColumn(
                name: "FollowedId",
                schema: "public",
                table: "person_followers",
                newName: "followed_id");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "person_followers",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "person_followers",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "person_followers",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "person_followers",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PersonFollowers_FollowerId_FollowedId",
                schema: "public",
                table: "person_followers",
                newName: "IX_person_followers_follower_id_followed_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonFollowers_FollowedId",
                schema: "public",
                table: "person_followers",
                newName: "IX_person_followers_followed_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonFollowers_Cod",
                schema: "public",
                table: "person_followers",
                newName: "IX_person_followers_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "person_documents",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Validate",
                schema: "public",
                table: "person_documents",
                newName: "validate");

            migrationBuilder.RenameColumn(
                name: "Standard",
                schema: "public",
                table: "person_documents",
                newName: "standard");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "person_documents",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "person_documents",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "person_documents",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "person_documents",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "person_documents",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "person_documents",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "person_documents",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DocumentTypeId",
                schema: "public",
                table: "person_documents",
                newName: "document_type_id");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                schema: "public",
                table: "person_documents",
                newName: "document_number");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "person_documents",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "person_documents",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "person_documents",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "person_documents",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryTypeId",
                schema: "public",
                table: "person_documents",
                newName: "category_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDocuments_PersonId_Standard",
                schema: "public",
                table: "person_documents",
                newName: "IX_person_documents_person_id_standard");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDocuments_DocumentTypeId",
                schema: "public",
                table: "person_documents",
                newName: "IX_person_documents_document_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDocuments_DocumentNumber_DocumentTypeId",
                schema: "public",
                table: "person_documents",
                newName: "IX_person_documents_document_number_document_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDocuments_Cod",
                schema: "public",
                table: "person_documents",
                newName: "IX_person_documents_cod");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDocuments_CategoryTypeId",
                schema: "public",
                table: "person_documents",
                newName: "IX_person_documents_category_type_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "person_contacts",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Standard",
                schema: "public",
                table: "person_contacts",
                newName: "standard");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "person_contacts",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "person_contacts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "person_contacts",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "person_contacts",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "person_contacts",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "person_contacts",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "person_contacts",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "person_contacts",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "person_contacts",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "person_contacts",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "person_contacts",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ContactValue",
                schema: "public",
                table: "person_contacts",
                newName: "contact_value");

            migrationBuilder.RenameColumn(
                name: "ContactTypeId",
                schema: "public",
                table: "person_contacts",
                newName: "contact_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonContacts_PersonId_Standard",
                schema: "public",
                table: "person_contacts",
                newName: "IX_person_contacts_person_id_standard");

            migrationBuilder.RenameIndex(
                name: "IX_PersonContacts_ContactValue",
                schema: "public",
                table: "person_contacts",
                newName: "IX_person_contacts_contact_value");

            migrationBuilder.RenameIndex(
                name: "IX_PersonContacts_ContactTypeId",
                schema: "public",
                table: "person_contacts",
                newName: "IX_person_contacts_contact_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonContacts_Cod",
                schema: "public",
                table: "person_contacts",
                newName: "IX_person_contacts_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "person_addresses",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Street",
                schema: "public",
                table: "person_addresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Standard",
                schema: "public",
                table: "person_addresses",
                newName: "standard");

            migrationBuilder.RenameColumn(
                name: "Number",
                schema: "public",
                table: "person_addresses",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Neighborhood",
                schema: "public",
                table: "person_addresses",
                newName: "neighborhood");

            migrationBuilder.RenameColumn(
                name: "Complement",
                schema: "public",
                table: "person_addresses",
                newName: "complement");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "person_addresses",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "person_addresses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                schema: "public",
                table: "person_addresses",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "person_addresses",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "person_addresses",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "person_addresses",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "person_addresses",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "person_addresses",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "person_addresses",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "person_addresses",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "person_addresses",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "person_addresses",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CityId",
                schema: "public",
                table: "person_addresses",
                newName: "city_id");

            migrationBuilder.RenameIndex(
                name: "IX_PersonAddresses_ZipCode",
                schema: "public",
                table: "person_addresses",
                newName: "IX_person_addresses_zip_code");

            migrationBuilder.RenameIndex(
                name: "IX_PersonAddresses_PersonId_Standard",
                schema: "public",
                table: "person_addresses",
                newName: "IX_person_addresses_person_id_standard");

            migrationBuilder.RenameIndex(
                name: "IX_PersonAddresses_Cod",
                schema: "public",
                table: "person_addresses",
                newName: "IX_person_addresses_cod");

            migrationBuilder.RenameIndex(
                name: "IX_PersonAddresses_CityId",
                schema: "public",
                table: "person_addresses",
                newName: "IX_person_addresses_city_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "occurrence_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "occurrence_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "occurrence_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "occurrence_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "occurrence_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "occurrence_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "occurrence_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "occurrence_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "occurrence_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "occurrence_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "occurrence_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "occurrence_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "occurrence_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "occurrence_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_OccurrenceTypes_Description",
                schema: "public",
                table: "occurrence_types",
                newName: "IX_occurrence_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_OccurrenceTypes_Cod",
                schema: "public",
                table: "occurrence_types",
                newName: "IX_occurrence_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "job_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "job_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "job_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "job_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "job_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "job_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "job_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "job_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "MaxImageCount",
                schema: "public",
                table: "job_types",
                newName: "max_image_count");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "job_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "job_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "job_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "job_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "job_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "job_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_JobTypes_Description",
                schema: "public",
                table: "job_types",
                newName: "IX_job_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_JobTypes_Cod",
                schema: "public",
                table: "job_types",
                newName: "IX_job_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "image_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "image_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "image_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "image_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "image_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "image_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "image_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "image_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "image_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "image_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "image_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "image_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "image_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "image_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ImageTypes_Description",
                schema: "public",
                table: "image_types",
                newName: "IX_image_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_ImageTypes_Cod",
                schema: "public",
                table: "image_types",
                newName: "IX_image_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "event_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "event_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "event_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "event_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "event_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "event_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "event_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "event_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "MaxImageCount",
                schema: "public",
                table: "event_types",
                newName: "max_image_count");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "event_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "event_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "event_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "event_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "event_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "event_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypes_Description",
                schema: "public",
                table: "event_types",
                newName: "IX_event_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_EventTypes_Cod",
                schema: "public",
                table: "event_types",
                newName: "IX_event_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "document_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "document_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "document_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "document_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "document_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "document_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "document_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "document_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "document_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "document_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "document_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "document_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "document_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "document_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentTypes_Description",
                schema: "public",
                table: "document_types",
                newName: "IX_document_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentTypes_Cod",
                schema: "public",
                table: "document_types",
                newName: "IX_document_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "contact_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "contact_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "contact_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "contact_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "contact_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "contact_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "contact_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "contact_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "contact_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "contact_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "contact_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "contact_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "contact_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "contact_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ContactTypes_Description",
                schema: "public",
                table: "contact_types",
                newName: "IX_contact_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_ContactTypes_Cod",
                schema: "public",
                table: "contact_types",
                newName: "IX_contact_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "category_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "category_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "category_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "category_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "category_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "category_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "category_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "category_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "category_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "category_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "category_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "category_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "category_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "category_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTypes_Description",
                schema: "public",
                table: "category_types",
                newName: "IX_category_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTypes_Cod",
                schema: "public",
                table: "category_types",
                newName: "IX_category_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "ad_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "ad_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "ad_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "ad_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "ad_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "ad_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "ad_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "ad_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "MaxImageCount",
                schema: "public",
                table: "ad_types",
                newName: "max_image_count");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "ad_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ad_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "ad_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ad_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "ad_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "ad_types",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_AdTypes_Description",
                schema: "public",
                table: "ad_types",
                newName: "IX_ad_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_AdTypes_Cod",
                schema: "public",
                table: "ad_types",
                newName: "IX_ad_types_cod");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "ad_sub_types",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "ad_sub_types",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "ad_sub_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "public",
                table: "ad_sub_types",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "ad_sub_types",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "ad_sub_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "ad_sub_types",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "ad_sub_types",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "ad_sub_types",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ad_sub_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "ad_sub_types",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ad_sub_types",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "ad_sub_types",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "ad_sub_types",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AdTypeId",
                schema: "public",
                table: "ad_sub_types",
                newName: "ad_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdSubTypes_Description",
                schema: "public",
                table: "ad_sub_types",
                newName: "IX_ad_sub_types_description");

            migrationBuilder.RenameIndex(
                name: "IX_AdSubTypes_Cod",
                schema: "public",
                table: "ad_sub_types",
                newName: "IX_ad_sub_types_cod");

            migrationBuilder.RenameIndex(
                name: "IX_AdSubTypes_AdTypeId",
                schema: "public",
                table: "ad_sub_types",
                newName: "IX_ad_sub_types_ad_type_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "ad_promotions",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "public",
                table: "ad_promotions",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "ad_promotions",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "ad_promotions",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "ad_promotions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "ad_promotions",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "ad_promotions",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "ad_promotions",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ad_promotions",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                schema: "public",
                table: "ad_promotions",
                newName: "expiration_date");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "ad_promotions",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ad_promotions",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "ad_promotions",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "ad_promotions",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AdId",
                schema: "public",
                table: "ad_promotions",
                newName: "ad_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdPromotions_ExpirationDate",
                schema: "public",
                table: "ad_promotions",
                newName: "IX_ad_promotions_expiration_date");

            migrationBuilder.RenameIndex(
                name: "IX_AdPromotions_Cod",
                schema: "public",
                table: "ad_promotions",
                newName: "IX_ad_promotions_cod");

            migrationBuilder.RenameIndex(
                name: "IX_AdPromotions_AdId",
                schema: "public",
                table: "ad_promotions",
                newName: "IX_ad_promotions_ad_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "ad_likes",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "ad_likes",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "ad_likes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "ad_likes",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "ad_likes",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "public",
                table: "ad_likes",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "ad_likes",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ad_likes",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "ad_likes",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ad_likes",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "ad_likes",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "ad_likes",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AdId",
                schema: "public",
                table: "ad_likes",
                newName: "ad_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdLikes_PersonId",
                schema: "public",
                table: "ad_likes",
                newName: "IX_ad_likes_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdLikes_Cod",
                schema: "public",
                table: "ad_likes",
                newName: "IX_ad_likes_cod");

            migrationBuilder.RenameIndex(
                name: "IX_AdLikes_AdId_PersonId",
                schema: "public",
                table: "ad_likes",
                newName: "IX_ad_likes_ad_id_person_id");

            migrationBuilder.RenameColumn(
                name: "Version",
                schema: "public",
                table: "ad_featured",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "ad_featured",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Cod",
                schema: "public",
                table: "ad_featured",
                newName: "cod");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "ad_featured",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                schema: "public",
                table: "ad_featured",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "ad_featured",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "public",
                table: "ad_featured",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ad_featured",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                schema: "public",
                table: "ad_featured",
                newName: "expiration_date");

            migrationBuilder.RenameColumn(
                name: "DeletedById",
                schema: "public",
                table: "ad_featured",
                newName: "deleted_by_id");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "ad_featured",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                schema: "public",
                table: "ad_featured",
                newName: "created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "ad_featured",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AdId",
                schema: "public",
                table: "ad_featured",
                newName: "ad_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdFeatureds_ExpirationDate",
                schema: "public",
                table: "ad_featured",
                newName: "IX_ad_featured_expiration_date");

            migrationBuilder.RenameIndex(
                name: "IX_AdFeatureds_Cod",
                schema: "public",
                table: "ad_featured",
                newName: "IX_ad_featured_cod");

            migrationBuilder.RenameIndex(
                name: "IX_AdFeatureds_AdId",
                schema: "public",
                table: "ad_featured",
                newName: "IX_ad_featured_ad_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_states",
                schema: "public",
                table: "states",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                schema: "public",
                table: "persons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_occurrences",
                schema: "public",
                table: "occurrences",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobs",
                schema: "public",
                table: "jobs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                schema: "public",
                table: "images",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedbacks",
                schema: "public",
                table: "feedbacks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorites",
                schema: "public",
                table: "favorites",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                schema: "public",
                table: "events",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                schema: "public",
                table: "cities",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ads",
                schema: "public",
                table: "ads",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_target_types",
                schema: "public",
                table: "target_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_social_media_types",
                schema: "public",
                table: "social_media_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_types",
                schema: "public",
                table: "person_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_social_medias",
                schema: "public",
                table: "person_social_medias",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_search_histories",
                schema: "public",
                table: "person_search_histories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_followers",
                schema: "public",
                table: "person_followers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_documents",
                schema: "public",
                table: "person_documents",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_contacts",
                schema: "public",
                table: "person_contacts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_addresses",
                schema: "public",
                table: "person_addresses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_occurrence_types",
                schema: "public",
                table: "occurrence_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_job_types",
                schema: "public",
                table: "job_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_image_types",
                schema: "public",
                table: "image_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event_types",
                schema: "public",
                table: "event_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_document_types",
                schema: "public",
                table: "document_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contact_types",
                schema: "public",
                table: "contact_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category_types",
                schema: "public",
                table: "category_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ad_types",
                schema: "public",
                table: "ad_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ad_sub_types",
                schema: "public",
                table: "ad_sub_types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ad_promotions",
                schema: "public",
                table: "ad_promotions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ad_likes",
                schema: "public",
                table: "ad_likes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ad_featured",
                schema: "public",
                table: "ad_featured",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ad_featured_ads_ad_id",
                schema: "public",
                table: "ad_featured",
                column: "ad_id",
                principalSchema: "public",
                principalTable: "ads",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ad_likes_ads_ad_id",
                schema: "public",
                table: "ad_likes",
                column: "ad_id",
                principalSchema: "public",
                principalTable: "ads",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ad_likes_persons_person_id",
                schema: "public",
                table: "ad_likes",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ad_promotions_ads_ad_id",
                schema: "public",
                table: "ad_promotions",
                column: "ad_id",
                principalSchema: "public",
                principalTable: "ads",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ad_sub_types_ad_types_ad_type_id",
                schema: "public",
                table: "ad_sub_types",
                column: "ad_type_id",
                principalSchema: "public",
                principalTable: "ad_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ads_ad_sub_types_ad_sub_type_id",
                schema: "public",
                table: "ads",
                column: "ad_sub_type_id",
                principalSchema: "public",
                principalTable: "ad_sub_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ads_ad_types_ad_type_id",
                schema: "public",
                table: "ads",
                column: "ad_type_id",
                principalSchema: "public",
                principalTable: "ad_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ads_cities_city_id",
                schema: "public",
                table: "ads",
                column: "city_id",
                principalSchema: "public",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ads_persons_person_id",
                schema: "public",
                table: "ads",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_states_state_id",
                schema: "public",
                table: "cities",
                column: "state_id",
                principalSchema: "public",
                principalTable: "states",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_events_cities_city_id",
                schema: "public",
                table: "events",
                column: "city_id",
                principalSchema: "public",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_events_contact_types_contact_type_id",
                schema: "public",
                table: "events",
                column: "contact_type_id",
                principalSchema: "public",
                principalTable: "contact_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_events_event_types_event_type_id",
                schema: "public",
                table: "events",
                column: "event_type_id",
                principalSchema: "public",
                principalTable: "event_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_events_persons_person_id",
                schema: "public",
                table: "events",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_persons_person_id",
                schema: "public",
                table: "favorites",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_target_types_target_type_id",
                schema: "public",
                table: "favorites",
                column: "target_type_id",
                principalSchema: "public",
                principalTable: "target_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_persons_person_id",
                schema: "public",
                table: "feedbacks",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_target_types_target_type_id",
                schema: "public",
                table: "feedbacks",
                column: "target_type_id",
                principalSchema: "public",
                principalTable: "target_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_images_ads_ad_id",
                schema: "public",
                table: "images",
                column: "ad_id",
                principalSchema: "public",
                principalTable: "ads",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_images_events_event_id",
                schema: "public",
                table: "images",
                column: "event_id",
                principalSchema: "public",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_images_image_types_image_type_id",
                schema: "public",
                table: "images",
                column: "image_type_id",
                principalSchema: "public",
                principalTable: "image_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_images_jobs_job_id",
                schema: "public",
                table: "images",
                column: "job_id",
                principalSchema: "public",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_images_persons_person_id",
                schema: "public",
                table: "images",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_contact_types_contact_type_id",
                schema: "public",
                table: "jobs",
                column: "contact_type_id",
                principalSchema: "public",
                principalTable: "contact_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_job_types_job_type_id",
                schema: "public",
                table: "jobs",
                column: "job_type_id",
                principalSchema: "public",
                principalTable: "job_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_persons_person_id",
                schema: "public",
                table: "jobs",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_occurrences_occurrence_types_occurrence_type_id",
                schema: "public",
                table: "occurrences",
                column: "occurrence_type_id",
                principalSchema: "public",
                principalTable: "occurrence_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_occurrences_persons_reported_by_id",
                schema: "public",
                table: "occurrences",
                column: "reported_by_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_occurrences_target_types_target_type_id",
                schema: "public",
                table: "occurrences",
                column: "target_type_id",
                principalSchema: "public",
                principalTable: "target_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_addresses_cities_city_id",
                schema: "public",
                table: "person_addresses",
                column: "city_id",
                principalSchema: "public",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_addresses_persons_person_id",
                schema: "public",
                table: "person_addresses",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_contacts_contact_types_contact_type_id",
                schema: "public",
                table: "person_contacts",
                column: "contact_type_id",
                principalSchema: "public",
                principalTable: "contact_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_contacts_persons_person_id",
                schema: "public",
                table: "person_contacts",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_documents_category_types_category_type_id",
                schema: "public",
                table: "person_documents",
                column: "category_type_id",
                principalSchema: "public",
                principalTable: "category_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_documents_document_types_document_type_id",
                schema: "public",
                table: "person_documents",
                column: "document_type_id",
                principalSchema: "public",
                principalTable: "document_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_documents_persons_person_id",
                schema: "public",
                table: "person_documents",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_followers_persons_followed_id",
                schema: "public",
                table: "person_followers",
                column: "followed_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_followers_persons_follower_id",
                schema: "public",
                table: "person_followers",
                column: "follower_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_search_histories_persons_person_id",
                schema: "public",
                table: "person_search_histories",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_social_medias_persons_person_id",
                schema: "public",
                table: "person_social_medias",
                column: "person_id",
                principalSchema: "public",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_social_medias_social_media_types_social_media_type_id",
                schema: "public",
                table: "person_social_medias",
                column: "social_media_type_id",
                principalSchema: "public",
                principalTable: "social_media_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_images_image_id",
                schema: "public",
                table: "persons",
                column: "image_id",
                principalSchema: "public",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_persons_person_types_person_type_id",
                schema: "public",
                table: "persons",
                column: "person_type_id",
                principalSchema: "public",
                principalTable: "person_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ad_featured_ads_ad_id",
                schema: "public",
                table: "ad_featured");

            migrationBuilder.DropForeignKey(
                name: "FK_ad_likes_ads_ad_id",
                schema: "public",
                table: "ad_likes");

            migrationBuilder.DropForeignKey(
                name: "FK_ad_likes_persons_person_id",
                schema: "public",
                table: "ad_likes");

            migrationBuilder.DropForeignKey(
                name: "FK_ad_promotions_ads_ad_id",
                schema: "public",
                table: "ad_promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ad_sub_types_ad_types_ad_type_id",
                schema: "public",
                table: "ad_sub_types");

            migrationBuilder.DropForeignKey(
                name: "FK_ads_ad_sub_types_ad_sub_type_id",
                schema: "public",
                table: "ads");

            migrationBuilder.DropForeignKey(
                name: "FK_ads_ad_types_ad_type_id",
                schema: "public",
                table: "ads");

            migrationBuilder.DropForeignKey(
                name: "FK_ads_cities_city_id",
                schema: "public",
                table: "ads");

            migrationBuilder.DropForeignKey(
                name: "FK_ads_persons_person_id",
                schema: "public",
                table: "ads");

            migrationBuilder.DropForeignKey(
                name: "FK_cities_states_state_id",
                schema: "public",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_events_cities_city_id",
                schema: "public",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_contact_types_contact_type_id",
                schema: "public",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_event_types_event_type_id",
                schema: "public",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_persons_person_id",
                schema: "public",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_persons_person_id",
                schema: "public",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_target_types_target_type_id",
                schema: "public",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_persons_person_id",
                schema: "public",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_target_types_target_type_id",
                schema: "public",
                table: "feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_images_ads_ad_id",
                schema: "public",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_images_events_event_id",
                schema: "public",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_images_image_types_image_type_id",
                schema: "public",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_images_jobs_job_id",
                schema: "public",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_images_persons_person_id",
                schema: "public",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_contact_types_contact_type_id",
                schema: "public",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_job_types_job_type_id",
                schema: "public",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_persons_person_id",
                schema: "public",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_occurrences_occurrence_types_occurrence_type_id",
                schema: "public",
                table: "occurrences");

            migrationBuilder.DropForeignKey(
                name: "FK_occurrences_persons_reported_by_id",
                schema: "public",
                table: "occurrences");

            migrationBuilder.DropForeignKey(
                name: "FK_occurrences_target_types_target_type_id",
                schema: "public",
                table: "occurrences");

            migrationBuilder.DropForeignKey(
                name: "FK_person_addresses_cities_city_id",
                schema: "public",
                table: "person_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_person_addresses_persons_person_id",
                schema: "public",
                table: "person_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_person_contacts_contact_types_contact_type_id",
                schema: "public",
                table: "person_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_person_contacts_persons_person_id",
                schema: "public",
                table: "person_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_person_documents_category_types_category_type_id",
                schema: "public",
                table: "person_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_person_documents_document_types_document_type_id",
                schema: "public",
                table: "person_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_person_documents_persons_person_id",
                schema: "public",
                table: "person_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_person_followers_persons_followed_id",
                schema: "public",
                table: "person_followers");

            migrationBuilder.DropForeignKey(
                name: "FK_person_followers_persons_follower_id",
                schema: "public",
                table: "person_followers");

            migrationBuilder.DropForeignKey(
                name: "FK_person_search_histories_persons_person_id",
                schema: "public",
                table: "person_search_histories");

            migrationBuilder.DropForeignKey(
                name: "FK_person_social_medias_persons_person_id",
                schema: "public",
                table: "person_social_medias");

            migrationBuilder.DropForeignKey(
                name: "FK_person_social_medias_social_media_types_social_media_type_id",
                schema: "public",
                table: "person_social_medias");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_images_image_id",
                schema: "public",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "FK_persons_person_types_person_type_id",
                schema: "public",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_states",
                schema: "public",
                table: "states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                schema: "public",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_occurrences",
                schema: "public",
                table: "occurrences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobs",
                schema: "public",
                table: "jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_images",
                schema: "public",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_feedbacks",
                schema: "public",
                table: "feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favorites",
                schema: "public",
                table: "favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                schema: "public",
                table: "events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                schema: "public",
                table: "cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ads",
                schema: "public",
                table: "ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_target_types",
                schema: "public",
                table: "target_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_social_media_types",
                schema: "public",
                table: "social_media_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_types",
                schema: "public",
                table: "person_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_social_medias",
                schema: "public",
                table: "person_social_medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_search_histories",
                schema: "public",
                table: "person_search_histories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_followers",
                schema: "public",
                table: "person_followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_documents",
                schema: "public",
                table: "person_documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_contacts",
                schema: "public",
                table: "person_contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_addresses",
                schema: "public",
                table: "person_addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_occurrence_types",
                schema: "public",
                table: "occurrence_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_job_types",
                schema: "public",
                table: "job_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_image_types",
                schema: "public",
                table: "image_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event_types",
                schema: "public",
                table: "event_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_document_types",
                schema: "public",
                table: "document_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contact_types",
                schema: "public",
                table: "contact_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category_types",
                schema: "public",
                table: "category_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ad_types",
                schema: "public",
                table: "ad_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ad_sub_types",
                schema: "public",
                table: "ad_sub_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ad_promotions",
                schema: "public",
                table: "ad_promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ad_likes",
                schema: "public",
                table: "ad_likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ad_featured",
                schema: "public",
                table: "ad_featured");

            migrationBuilder.RenameTable(
                name: "states",
                schema: "public",
                newName: "States",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "persons",
                schema: "public",
                newName: "Persons",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "occurrences",
                schema: "public",
                newName: "Occurrences",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "jobs",
                schema: "public",
                newName: "Jobs",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "images",
                schema: "public",
                newName: "Images",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "feedbacks",
                schema: "public",
                newName: "Feedbacks",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "favorites",
                schema: "public",
                newName: "Favorites",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "events",
                schema: "public",
                newName: "Events",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "cities",
                schema: "public",
                newName: "Cities",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ads",
                schema: "public",
                newName: "Ads",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "target_types",
                schema: "public",
                newName: "TargetTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "social_media_types",
                schema: "public",
                newName: "SocialMediaTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "person_types",
                schema: "public",
                newName: "PersonTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "person_social_medias",
                schema: "public",
                newName: "PersonSocialMedias",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "person_search_histories",
                schema: "public",
                newName: "PersonSearchHistories",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "person_followers",
                schema: "public",
                newName: "PersonFollowers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "person_documents",
                schema: "public",
                newName: "PersonDocuments",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "person_contacts",
                schema: "public",
                newName: "PersonContacts",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "person_addresses",
                schema: "public",
                newName: "PersonAddresses",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "occurrence_types",
                schema: "public",
                newName: "OccurrenceTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "job_types",
                schema: "public",
                newName: "JobTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "image_types",
                schema: "public",
                newName: "ImageTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "event_types",
                schema: "public",
                newName: "EventTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "document_types",
                schema: "public",
                newName: "DocumentTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "contact_types",
                schema: "public",
                newName: "ContactTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "category_types",
                schema: "public",
                newName: "CategoryTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ad_types",
                schema: "public",
                newName: "AdTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ad_sub_types",
                schema: "public",
                newName: "AdSubTypes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ad_promotions",
                schema: "public",
                newName: "AdPromotions",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ad_likes",
                schema: "public",
                newName: "AdLikes",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "ad_featured",
                schema: "public",
                newName: "AdFeatureds",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "States",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "uf",
                schema: "public",
                table: "States",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "States",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "States",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "States",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "States",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "States",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "States",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "States",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "ibge_code",
                schema: "public",
                table: "States",
                newName: "IbgeCode");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "States",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "States",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "States",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "States",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_states_uf",
                schema: "public",
                table: "States",
                newName: "IX_States_Uf");

            migrationBuilder.RenameIndex(
                name: "IX_states_name",
                schema: "public",
                table: "States",
                newName: "IX_States_Name");

            migrationBuilder.RenameIndex(
                name: "IX_states_cod",
                schema: "public",
                table: "States",
                newName: "IX_States_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_states_ibge_code",
                schema: "public",
                table: "States",
                newName: "IX_States_IbgeCode");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Persons",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "Persons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Persons",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "birth",
                schema: "public",
                table: "Persons",
                newName: "Birth");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Persons",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Persons",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_type_id",
                schema: "public",
                table: "Persons",
                newName: "PersonTypeId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Persons",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Persons",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "image_id",
                schema: "public",
                table: "Persons",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Persons",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Persons",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Persons",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Persons",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_persons_name_birth",
                schema: "public",
                table: "Persons",
                newName: "IX_Persons_Name_Birth");

            migrationBuilder.RenameIndex(
                name: "IX_persons_cod",
                schema: "public",
                table: "Persons",
                newName: "IX_Persons_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_persons_person_type_id",
                schema: "public",
                table: "Persons",
                newName: "IX_Persons_PersonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_persons_image_id",
                schema: "public",
                table: "Persons",
                newName: "IX_Persons_ImageId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Occurrences",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "resolved",
                schema: "public",
                table: "Occurrences",
                newName: "Resolved");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "Occurrences",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Occurrences",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Occurrences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Occurrences",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Occurrences",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "target_type_id",
                schema: "public",
                table: "Occurrences",
                newName: "TargetTypeId");

            migrationBuilder.RenameColumn(
                name: "target_id",
                schema: "public",
                table: "Occurrences",
                newName: "TargetId");

            migrationBuilder.RenameColumn(
                name: "resolved_at",
                schema: "public",
                table: "Occurrences",
                newName: "ResolvedAt");

            migrationBuilder.RenameColumn(
                name: "resolution_comment",
                schema: "public",
                table: "Occurrences",
                newName: "ResolutionComment");

            migrationBuilder.RenameColumn(
                name: "reported_by_id",
                schema: "public",
                table: "Occurrences",
                newName: "ReportedById");

            migrationBuilder.RenameColumn(
                name: "occurrence_type_id",
                schema: "public",
                table: "Occurrences",
                newName: "OccurrenceTypeId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Occurrences",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Occurrences",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Occurrences",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Occurrences",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Occurrences",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Occurrences",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_occurrences_cod",
                schema: "public",
                table: "Occurrences",
                newName: "IX_Occurrences_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_occurrences_target_type_id",
                schema: "public",
                table: "Occurrences",
                newName: "IX_Occurrences_TargetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_occurrences_reported_by_id_target_id_target_type_id",
                schema: "public",
                table: "Occurrences",
                newName: "IX_Occurrences_ReportedById_TargetId_TargetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_occurrences_occurrence_type_id",
                schema: "public",
                table: "Occurrences",
                newName: "IX_Occurrences_OccurrenceTypeId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Jobs",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "salary",
                schema: "public",
                table: "Jobs",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "Jobs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "contact",
                schema: "public",
                table: "Jobs",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Jobs",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Jobs",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Jobs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "Jobs",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "job_type_id",
                schema: "public",
                table: "Jobs",
                newName: "JobTypeId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Jobs",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Jobs",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "expiration_date",
                schema: "public",
                table: "Jobs",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Jobs",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Jobs",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Jobs",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Jobs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "contact_type_id",
                schema: "public",
                table: "Jobs",
                newName: "ContactTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_cod",
                schema: "public",
                table: "Jobs",
                newName: "IX_Jobs_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_person_id",
                schema: "public",
                table: "Jobs",
                newName: "IX_Jobs_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_job_type_id",
                schema: "public",
                table: "Jobs",
                newName: "IX_Jobs_JobTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_contact_type_id",
                schema: "public",
                table: "Jobs",
                newName: "IX_Jobs_ContactTypeId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Images",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "url",
                schema: "public",
                table: "Images",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "size",
                schema: "public",
                table: "Images",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Images",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Images",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Images",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Images",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "Images",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "job_id",
                schema: "public",
                table: "Images",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Images",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Images",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "image_type_id",
                schema: "public",
                table: "Images",
                newName: "ImageTypeId");

            migrationBuilder.RenameColumn(
                name: "file_name",
                schema: "public",
                table: "Images",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "event_id",
                schema: "public",
                table: "Images",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Images",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Images",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Images",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Images",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "content_type",
                schema: "public",
                table: "Images",
                newName: "ContentType");

            migrationBuilder.RenameColumn(
                name: "container_name",
                schema: "public",
                table: "Images",
                newName: "ContainerName");

            migrationBuilder.RenameColumn(
                name: "ad_id",
                schema: "public",
                table: "Images",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_images_cod",
                schema: "public",
                table: "Images",
                newName: "IX_Images_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_images_person_id",
                schema: "public",
                table: "Images",
                newName: "IX_Images_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_images_job_id",
                schema: "public",
                table: "Images",
                newName: "IX_Images_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_images_image_type_id",
                schema: "public",
                table: "Images",
                newName: "IX_Images_ImageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_images_event_id",
                schema: "public",
                table: "Images",
                newName: "IX_Images_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_images_ad_id",
                schema: "public",
                table: "Images",
                newName: "IX_Images_AdId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Feedbacks",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "rating",
                schema: "public",
                table: "Feedbacks",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "comment",
                schema: "public",
                table: "Feedbacks",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Feedbacks",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Feedbacks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Feedbacks",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Feedbacks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "target_type_id",
                schema: "public",
                table: "Feedbacks",
                newName: "TargetTypeId");

            migrationBuilder.RenameColumn(
                name: "target_id",
                schema: "public",
                table: "Feedbacks",
                newName: "TargetId");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "Feedbacks",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Feedbacks",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Feedbacks",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Feedbacks",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Feedbacks",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Feedbacks",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Feedbacks",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_cod",
                schema: "public",
                table: "Feedbacks",
                newName: "IX_Feedbacks_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_target_type_id",
                schema: "public",
                table: "Feedbacks",
                newName: "IX_Feedbacks_TargetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_person_id_target_id_target_type_id",
                schema: "public",
                table: "Feedbacks",
                newName: "IX_Feedbacks_PersonId_TargetId_TargetTypeId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Favorites",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Favorites",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Favorites",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Favorites",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Favorites",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "target_type_id",
                schema: "public",
                table: "Favorites",
                newName: "TargetTypeId");

            migrationBuilder.RenameColumn(
                name: "target_id",
                schema: "public",
                table: "Favorites",
                newName: "TargetId");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "Favorites",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Favorites",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Favorites",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Favorites",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Favorites",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Favorites",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Favorites",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_favorites_cod",
                schema: "public",
                table: "Favorites",
                newName: "IX_Favorites_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_favorites_target_type_id",
                schema: "public",
                table: "Favorites",
                newName: "IX_Favorites_TargetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_favorites_person_id_target_id_target_type_id",
                schema: "public",
                table: "Favorites",
                newName: "IX_Favorites_PersonId_TargetId_TargetTypeId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Events",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "title",
                schema: "public",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "public",
                table: "Events",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "location",
                schema: "public",
                table: "Events",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "contact",
                schema: "public",
                table: "Events",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Events",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Events",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Events",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "start_date",
                schema: "public",
                table: "Events",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "Events",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_public",
                schema: "public",
                table: "Events",
                newName: "IsPublic");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Events",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Events",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "external_url",
                schema: "public",
                table: "Events",
                newName: "ExternalUrl");

            migrationBuilder.RenameColumn(
                name: "expiration_date",
                schema: "public",
                table: "Events",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "event_type_id",
                schema: "public",
                table: "Events",
                newName: "EventTypeId");

            migrationBuilder.RenameColumn(
                name: "end_date",
                schema: "public",
                table: "Events",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Events",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Events",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Events",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Events",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "contact_type_id",
                schema: "public",
                table: "Events",
                newName: "ContactTypeId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                schema: "public",
                table: "Events",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_events_cod",
                schema: "public",
                table: "Events",
                newName: "IX_Events_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_events_person_id",
                schema: "public",
                table: "Events",
                newName: "IX_Events_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_events_event_type_id",
                schema: "public",
                table: "Events",
                newName: "IX_Events_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_events_contact_type_id",
                schema: "public",
                table: "Events",
                newName: "IX_Events_ContactTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_events_city_id",
                schema: "public",
                table: "Events",
                newName: "IX_Events_CityId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Cities",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "Cities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Cities",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Cities",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Cities",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "state_id",
                schema: "public",
                table: "Cities",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Cities",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Cities",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "ibge_code",
                schema: "public",
                table: "Cities",
                newName: "IbgeCode");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Cities",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Cities",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Cities",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Cities",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_cities_name",
                schema: "public",
                table: "Cities",
                newName: "IX_Cities_Name");

            migrationBuilder.RenameIndex(
                name: "IX_cities_cod",
                schema: "public",
                table: "Cities",
                newName: "IX_Cities_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_cities_state_id",
                schema: "public",
                table: "Cities",
                newName: "IX_Cities_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_cities_ibge_code",
                schema: "public",
                table: "Cities",
                newName: "IX_Cities_IbgeCode");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "Ads",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "title",
                schema: "public",
                table: "Ads",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "promotion",
                schema: "public",
                table: "Ads",
                newName: "Promotion");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "public",
                table: "Ads",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "donation",
                schema: "public",
                table: "Ads",
                newName: "Donation");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "Ads",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "contact",
                schema: "public",
                table: "Ads",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "Ads",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Ads",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "views_count",
                schema: "public",
                table: "Ads",
                newName: "ViewsCount");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "Ads",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "Ads",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "Ads",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "Ads",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "Ads",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "expiration_date",
                schema: "public",
                table: "Ads",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "Ads",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "Ads",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "Ads",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "Ads",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "city_id",
                schema: "public",
                table: "Ads",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "ad_type_id",
                schema: "public",
                table: "Ads",
                newName: "AdTypeId");

            migrationBuilder.RenameColumn(
                name: "ad_sub_type_id",
                schema: "public",
                table: "Ads",
                newName: "AdSubTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ads_title",
                schema: "public",
                table: "Ads",
                newName: "IX_Ads_Title");

            migrationBuilder.RenameIndex(
                name: "IX_ads_price",
                schema: "public",
                table: "Ads",
                newName: "IX_Ads_Price");

            migrationBuilder.RenameIndex(
                name: "IX_ads_cod",
                schema: "public",
                table: "Ads",
                newName: "IX_Ads_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_ads_person_id",
                schema: "public",
                table: "Ads",
                newName: "IX_Ads_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ads_city_id",
                schema: "public",
                table: "Ads",
                newName: "IX_Ads_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_ads_ad_type_id",
                schema: "public",
                table: "Ads",
                newName: "IX_Ads_AdTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ads_ad_sub_type_id",
                schema: "public",
                table: "Ads",
                newName: "IX_Ads_AdSubTypeId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "TargetTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "TargetTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "TargetTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "TargetTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "TargetTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "TargetTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "TargetTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "TargetTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "TargetTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "TargetTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "TargetTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "TargetTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "TargetTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "TargetTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_target_types_description",
                schema: "public",
                table: "TargetTypes",
                newName: "IX_TargetTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_target_types_cod",
                schema: "public",
                table: "TargetTypes",
                newName: "IX_TargetTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_social_media_types_description",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "IX_SocialMediaTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_social_media_types_cod",
                schema: "public",
                table: "SocialMediaTypes",
                newName: "IX_SocialMediaTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "PersonTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "PersonTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "PersonTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "PersonTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "PersonTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "PersonTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "PersonTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "PersonTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "PersonTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "PersonTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "PersonTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "PersonTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "PersonTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "PersonTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_person_types_description",
                schema: "public",
                table: "PersonTypes",
                newName: "IX_PersonTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_person_types_cod",
                schema: "public",
                table: "PersonTypes",
                newName: "IX_PersonTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "social_media_type_id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "SocialMediaTypeId");

            migrationBuilder.RenameColumn(
                name: "profile_url",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "ProfileUrl");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_person_social_medias_social_media_type_id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "IX_PersonSocialMedias_SocialMediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_person_social_medias_person_id_social_media_type_id",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "IX_PersonSocialMedias_PersonId_SocialMediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_person_social_medias_cod",
                schema: "public",
                table: "PersonSocialMedias",
                newName: "IX_PersonSocialMedias_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "query",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "Query");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "searched_at",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "SearchedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_person_search_histories_person_id",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "IX_PersonSearchHistories_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_person_search_histories_cod",
                schema: "public",
                table: "PersonSearchHistories",
                newName: "IX_PersonSearchHistories_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "PersonFollowers",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "PersonFollowers",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "PersonFollowers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "PersonFollowers",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "PersonFollowers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "PersonFollowers",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "PersonFollowers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "follower_id",
                schema: "public",
                table: "PersonFollowers",
                newName: "FollowerId");

            migrationBuilder.RenameColumn(
                name: "followed_id",
                schema: "public",
                table: "PersonFollowers",
                newName: "FollowedId");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "PersonFollowers",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "PersonFollowers",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "PersonFollowers",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "PersonFollowers",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_person_followers_follower_id_followed_id",
                schema: "public",
                table: "PersonFollowers",
                newName: "IX_PersonFollowers_FollowerId_FollowedId");

            migrationBuilder.RenameIndex(
                name: "IX_person_followers_followed_id",
                schema: "public",
                table: "PersonFollowers",
                newName: "IX_PersonFollowers_FollowedId");

            migrationBuilder.RenameIndex(
                name: "IX_person_followers_cod",
                schema: "public",
                table: "PersonFollowers",
                newName: "IX_PersonFollowers_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "PersonDocuments",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "validate",
                schema: "public",
                table: "PersonDocuments",
                newName: "Validate");

            migrationBuilder.RenameColumn(
                name: "standard",
                schema: "public",
                table: "PersonDocuments",
                newName: "Standard");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "PersonDocuments",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "PersonDocuments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "PersonDocuments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "PersonDocuments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "PersonDocuments",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "document_type_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "document_number",
                schema: "public",
                table: "PersonDocuments",
                newName: "DocumentNumber");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "PersonDocuments",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "PersonDocuments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_type_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "CategoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_person_documents_person_id_standard",
                schema: "public",
                table: "PersonDocuments",
                newName: "IX_PersonDocuments_PersonId_Standard");

            migrationBuilder.RenameIndex(
                name: "IX_person_documents_document_type_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "IX_PersonDocuments_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_person_documents_document_number_document_type_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "IX_PersonDocuments_DocumentNumber_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_person_documents_cod",
                schema: "public",
                table: "PersonDocuments",
                newName: "IX_PersonDocuments_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_person_documents_category_type_id",
                schema: "public",
                table: "PersonDocuments",
                newName: "IX_PersonDocuments_CategoryTypeId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "PersonContacts",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "standard",
                schema: "public",
                table: "PersonContacts",
                newName: "Standard");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "PersonContacts",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "PersonContacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "PersonContacts",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "PersonContacts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "PersonContacts",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "PersonContacts",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "PersonContacts",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "PersonContacts",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "PersonContacts",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "PersonContacts",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "PersonContacts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "contact_value",
                schema: "public",
                table: "PersonContacts",
                newName: "ContactValue");

            migrationBuilder.RenameColumn(
                name: "contact_type_id",
                schema: "public",
                table: "PersonContacts",
                newName: "ContactTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_person_contacts_person_id_standard",
                schema: "public",
                table: "PersonContacts",
                newName: "IX_PersonContacts_PersonId_Standard");

            migrationBuilder.RenameIndex(
                name: "IX_person_contacts_contact_value",
                schema: "public",
                table: "PersonContacts",
                newName: "IX_PersonContacts_ContactValue");

            migrationBuilder.RenameIndex(
                name: "IX_person_contacts_contact_type_id",
                schema: "public",
                table: "PersonContacts",
                newName: "IX_PersonContacts_ContactTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_person_contacts_cod",
                schema: "public",
                table: "PersonContacts",
                newName: "IX_PersonContacts_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "PersonAddresses",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "street",
                schema: "public",
                table: "PersonAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "standard",
                schema: "public",
                table: "PersonAddresses",
                newName: "Standard");

            migrationBuilder.RenameColumn(
                name: "number",
                schema: "public",
                table: "PersonAddresses",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "neighborhood",
                schema: "public",
                table: "PersonAddresses",
                newName: "Neighborhood");

            migrationBuilder.RenameColumn(
                name: "complement",
                schema: "public",
                table: "PersonAddresses",
                newName: "Complement");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "PersonAddresses",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "PersonAddresses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                schema: "public",
                table: "PersonAddresses",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "PersonAddresses",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "PersonAddresses",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "PersonAddresses",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "PersonAddresses",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "PersonAddresses",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "PersonAddresses",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "PersonAddresses",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "PersonAddresses",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "PersonAddresses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "city_id",
                schema: "public",
                table: "PersonAddresses",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_person_addresses_zip_code",
                schema: "public",
                table: "PersonAddresses",
                newName: "IX_PersonAddresses_ZipCode");

            migrationBuilder.RenameIndex(
                name: "IX_person_addresses_person_id_standard",
                schema: "public",
                table: "PersonAddresses",
                newName: "IX_PersonAddresses_PersonId_Standard");

            migrationBuilder.RenameIndex(
                name: "IX_person_addresses_cod",
                schema: "public",
                table: "PersonAddresses",
                newName: "IX_PersonAddresses_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_person_addresses_city_id",
                schema: "public",
                table: "PersonAddresses",
                newName: "IX_PersonAddresses_CityId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_occurrence_types_description",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "IX_OccurrenceTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_occurrence_types_cod",
                schema: "public",
                table: "OccurrenceTypes",
                newName: "IX_OccurrenceTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "JobTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "JobTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "JobTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "JobTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "JobTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "JobTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "JobTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "JobTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "max_image_count",
                schema: "public",
                table: "JobTypes",
                newName: "MaxImageCount");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "JobTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "JobTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "JobTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "JobTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "JobTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "JobTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_job_types_description",
                schema: "public",
                table: "JobTypes",
                newName: "IX_JobTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_job_types_cod",
                schema: "public",
                table: "JobTypes",
                newName: "IX_JobTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "ImageTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "ImageTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "ImageTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "ImageTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "ImageTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "ImageTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "ImageTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "ImageTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "ImageTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "ImageTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "ImageTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "ImageTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "ImageTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "ImageTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_image_types_description",
                schema: "public",
                table: "ImageTypes",
                newName: "IX_ImageTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_image_types_cod",
                schema: "public",
                table: "ImageTypes",
                newName: "IX_ImageTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "EventTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "EventTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "EventTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "EventTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "EventTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "EventTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "EventTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "EventTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "max_image_count",
                schema: "public",
                table: "EventTypes",
                newName: "MaxImageCount");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "EventTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "EventTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "EventTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "EventTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "EventTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "EventTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_event_types_description",
                schema: "public",
                table: "EventTypes",
                newName: "IX_EventTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_event_types_cod",
                schema: "public",
                table: "EventTypes",
                newName: "IX_EventTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "DocumentTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "DocumentTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "DocumentTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "DocumentTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "DocumentTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "DocumentTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "DocumentTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "DocumentTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "DocumentTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "DocumentTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "DocumentTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "DocumentTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "DocumentTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "DocumentTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_document_types_description",
                schema: "public",
                table: "DocumentTypes",
                newName: "IX_DocumentTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_document_types_cod",
                schema: "public",
                table: "DocumentTypes",
                newName: "IX_DocumentTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "ContactTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "ContactTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "ContactTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "ContactTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "ContactTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "ContactTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "ContactTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "ContactTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "ContactTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "ContactTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "ContactTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "ContactTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "ContactTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "ContactTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_contact_types_description",
                schema: "public",
                table: "ContactTypes",
                newName: "IX_ContactTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_contact_types_cod",
                schema: "public",
                table: "ContactTypes",
                newName: "IX_ContactTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "CategoryTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "CategoryTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "CategoryTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "CategoryTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "CategoryTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "CategoryTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "CategoryTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "CategoryTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "CategoryTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "CategoryTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "CategoryTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "CategoryTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "CategoryTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "CategoryTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_category_types_description",
                schema: "public",
                table: "CategoryTypes",
                newName: "IX_CategoryTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_category_types_cod",
                schema: "public",
                table: "CategoryTypes",
                newName: "IX_CategoryTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "AdTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "AdTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "AdTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "AdTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "AdTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "AdTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "AdTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "AdTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "max_image_count",
                schema: "public",
                table: "AdTypes",
                newName: "MaxImageCount");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "AdTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "AdTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "AdTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "AdTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "AdTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "AdTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_ad_types_description",
                schema: "public",
                table: "AdTypes",
                newName: "IX_AdTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_ad_types_cod",
                schema: "public",
                table: "AdTypes",
                newName: "IX_AdTypes_Cod");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "AdSubTypes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "icon",
                schema: "public",
                table: "AdSubTypes",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "AdSubTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "public",
                table: "AdSubTypes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "AdSubTypes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "AdSubTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "AdSubTypes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "AdSubTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "AdSubTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "AdSubTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "AdSubTypes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "AdSubTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "AdSubTypes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "AdSubTypes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ad_type_id",
                schema: "public",
                table: "AdSubTypes",
                newName: "AdTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ad_sub_types_description",
                schema: "public",
                table: "AdSubTypes",
                newName: "IX_AdSubTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_ad_sub_types_cod",
                schema: "public",
                table: "AdSubTypes",
                newName: "IX_AdSubTypes_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_ad_sub_types_ad_type_id",
                schema: "public",
                table: "AdSubTypes",
                newName: "IX_AdSubTypes_AdTypeId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "AdPromotions",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "public",
                table: "AdPromotions",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "AdPromotions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "AdPromotions",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "AdPromotions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "AdPromotions",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "AdPromotions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "AdPromotions",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "AdPromotions",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "expiration_date",
                schema: "public",
                table: "AdPromotions",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "AdPromotions",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "AdPromotions",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "AdPromotions",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "AdPromotions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ad_id",
                schema: "public",
                table: "AdPromotions",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_ad_promotions_expiration_date",
                schema: "public",
                table: "AdPromotions",
                newName: "IX_AdPromotions_ExpirationDate");

            migrationBuilder.RenameIndex(
                name: "IX_ad_promotions_cod",
                schema: "public",
                table: "AdPromotions",
                newName: "IX_AdPromotions_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_ad_promotions_ad_id",
                schema: "public",
                table: "AdPromotions",
                newName: "IX_AdPromotions_AdId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "AdLikes",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "AdLikes",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "AdLikes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "AdLikes",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "AdLikes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "person_id",
                schema: "public",
                table: "AdLikes",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "AdLikes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "AdLikes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "AdLikes",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "AdLikes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "AdLikes",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "AdLikes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ad_id",
                schema: "public",
                table: "AdLikes",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_ad_likes_person_id",
                schema: "public",
                table: "AdLikes",
                newName: "IX_AdLikes_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ad_likes_cod",
                schema: "public",
                table: "AdLikes",
                newName: "IX_AdLikes_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_ad_likes_ad_id_person_id",
                schema: "public",
                table: "AdLikes",
                newName: "IX_AdLikes_AdId_PersonId");

            migrationBuilder.RenameColumn(
                name: "version",
                schema: "public",
                table: "AdFeatureds",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "AdFeatureds",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cod",
                schema: "public",
                table: "AdFeatureds",
                newName: "Cod");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "AdFeatureds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                schema: "public",
                table: "AdFeatureds",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "AdFeatureds",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "public",
                table: "AdFeatureds",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "AdFeatureds",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "expiration_date",
                schema: "public",
                table: "AdFeatureds",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "deleted_by_id",
                schema: "public",
                table: "AdFeatureds",
                newName: "DeletedById");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "AdFeatureds",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                schema: "public",
                table: "AdFeatureds",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "AdFeatureds",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ad_id",
                schema: "public",
                table: "AdFeatureds",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_ad_featured_expiration_date",
                schema: "public",
                table: "AdFeatureds",
                newName: "IX_AdFeatureds_ExpirationDate");

            migrationBuilder.RenameIndex(
                name: "IX_ad_featured_cod",
                schema: "public",
                table: "AdFeatureds",
                newName: "IX_AdFeatureds_Cod");

            migrationBuilder.RenameIndex(
                name: "IX_ad_featured_ad_id",
                schema: "public",
                table: "AdFeatureds",
                newName: "IX_AdFeatureds_AdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                schema: "public",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                schema: "public",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occurrences",
                schema: "public",
                table: "Occurrences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                schema: "public",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                schema: "public",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                schema: "public",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                schema: "public",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                schema: "public",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                schema: "public",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                schema: "public",
                table: "Ads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TargetTypes",
                schema: "public",
                table: "TargetTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMediaTypes",
                schema: "public",
                table: "SocialMediaTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonTypes",
                schema: "public",
                table: "PersonTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSocialMedias",
                schema: "public",
                table: "PersonSocialMedias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSearchHistories",
                schema: "public",
                table: "PersonSearchHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonFollowers",
                schema: "public",
                table: "PersonFollowers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDocuments",
                schema: "public",
                table: "PersonDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonContacts",
                schema: "public",
                table: "PersonContacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonAddresses",
                schema: "public",
                table: "PersonAddresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccurrenceTypes",
                schema: "public",
                table: "OccurrenceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTypes",
                schema: "public",
                table: "JobTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageTypes",
                schema: "public",
                table: "ImageTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTypes",
                schema: "public",
                table: "EventTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypes",
                schema: "public",
                table: "DocumentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactTypes",
                schema: "public",
                table: "ContactTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTypes",
                schema: "public",
                table: "CategoryTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdTypes",
                schema: "public",
                table: "AdTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdSubTypes",
                schema: "public",
                table: "AdSubTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdPromotions",
                schema: "public",
                table: "AdPromotions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdLikes",
                schema: "public",
                table: "AdLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdFeatureds",
                schema: "public",
                table: "AdFeatureds",
                column: "Id");

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
                name: "FK_Ads_AdSubTypes_AdSubTypeId",
                schema: "public",
                table: "Ads",
                column: "AdSubTypeId",
                principalSchema: "public",
                principalTable: "AdSubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdTypes_AdTypeId",
                schema: "public",
                table: "Ads",
                column: "AdTypeId",
                principalSchema: "public",
                principalTable: "AdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Cities_CityId",
                schema: "public",
                table: "Ads",
                column: "CityId",
                principalSchema: "public",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AdSubTypes_AdTypes_AdTypeId",
                schema: "public",
                table: "AdSubTypes",
                column: "AdTypeId",
                principalSchema: "public",
                principalTable: "AdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                schema: "public",
                table: "Cities",
                column: "StateId",
                principalSchema: "public",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Cities_CityId",
                schema: "public",
                table: "Events",
                column: "CityId",
                principalSchema: "public",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ContactTypes_ContactTypeId",
                schema: "public",
                table: "Events",
                column: "ContactTypeId",
                principalSchema: "public",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                schema: "public",
                table: "Events",
                column: "EventTypeId",
                principalSchema: "public",
                principalTable: "EventTypes",
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
                name: "FK_Favorites_TargetTypes_TargetTypeId",
                schema: "public",
                table: "Favorites",
                column: "TargetTypeId",
                principalSchema: "public",
                principalTable: "TargetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Feedbacks_TargetTypes_TargetTypeId",
                schema: "public",
                table: "Feedbacks",
                column: "TargetTypeId",
                principalSchema: "public",
                principalTable: "TargetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ads_AdId",
                schema: "public",
                table: "Images",
                column: "AdId",
                principalSchema: "public",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventId",
                schema: "public",
                table: "Images",
                column: "EventId",
                principalSchema: "public",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ImageTypes_ImageTypeId",
                schema: "public",
                table: "Images",
                column: "ImageTypeId",
                principalSchema: "public",
                principalTable: "ImageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_ContactTypes_ContactTypeId",
                schema: "public",
                table: "Jobs",
                column: "ContactTypeId",
                principalSchema: "public",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                schema: "public",
                table: "Jobs",
                column: "JobTypeId",
                principalSchema: "public",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Persons_PersonId",
                schema: "public",
                table: "Jobs",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Occurrences_OccurrenceTypes_OccurrenceTypeId",
                schema: "public",
                table: "Occurrences",
                column: "OccurrenceTypeId",
                principalSchema: "public",
                principalTable: "OccurrenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Occurrences_Persons_ReportedById",
                schema: "public",
                table: "Occurrences",
                column: "ReportedById",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Occurrences_TargetTypes_TargetTypeId",
                schema: "public",
                table: "Occurrences",
                column: "TargetTypeId",
                principalSchema: "public",
                principalTable: "TargetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAddresses_Cities_CityId",
                schema: "public",
                table: "PersonAddresses",
                column: "CityId",
                principalSchema: "public",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAddresses_Persons_PersonId",
                schema: "public",
                table: "PersonAddresses",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContacts_ContactTypes_ContactTypeId",
                schema: "public",
                table: "PersonContacts",
                column: "ContactTypeId",
                principalSchema: "public",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContacts_Persons_PersonId",
                schema: "public",
                table: "PersonContacts",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDocuments_CategoryTypes_CategoryTypeId",
                schema: "public",
                table: "PersonDocuments",
                column: "CategoryTypeId",
                principalSchema: "public",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDocuments_DocumentTypes_DocumentTypeId",
                schema: "public",
                table: "PersonDocuments",
                column: "DocumentTypeId",
                principalSchema: "public",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDocuments_Persons_PersonId",
                schema: "public",
                table: "PersonDocuments",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonFollowers_Persons_FollowedId",
                schema: "public",
                table: "PersonFollowers",
                column: "FollowedId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonFollowers_Persons_FollowerId",
                schema: "public",
                table: "PersonFollowers",
                column: "FollowerId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Images_ImageId",
                schema: "public",
                table: "Persons",
                column: "ImageId",
                principalSchema: "public",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                schema: "public",
                table: "Persons",
                column: "PersonTypeId",
                principalSchema: "public",
                principalTable: "PersonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSearchHistories_Persons_PersonId",
                schema: "public",
                table: "PersonSearchHistories",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSocialMedias_Persons_PersonId",
                schema: "public",
                table: "PersonSocialMedias",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSocialMedias_SocialMediaTypes_SocialMediaTypeId",
                schema: "public",
                table: "PersonSocialMedias",
                column: "SocialMediaTypeId",
                principalSchema: "public",
                principalTable: "SocialMediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
