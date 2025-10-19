using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppilar.Auth.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "ident",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "ident",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                schema: "ident",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                schema: "ident",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "ident",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "ident",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "ident",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "ident",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "ident",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "ident",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "ident",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                schema: "ident",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                schema: "ident",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                schema: "ident",
                table: "RoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "ident",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "ident",
                newName: "users",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "ident",
                newName: "roles",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "ident",
                newName: "user_tokens",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "ident",
                newName: "user_roles",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "ident",
                newName: "user_logins",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "ident",
                newName: "user_claims",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "ident",
                newName: "role_claims",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                schema: "ident",
                newName: "refresh_tokens",
                newSchema: "ident");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                schema: "ident",
                table: "user_roles",
                newName: "IX_user_roles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                schema: "ident",
                table: "user_logins",
                newName: "IX_user_logins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                schema: "ident",
                table: "user_claims",
                newName: "IX_user_claims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "ident",
                table: "role_claims",
                newName: "IX_role_claims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "ident",
                table: "refresh_tokens",
                newName: "IX_refresh_tokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "ident",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                schema: "ident",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_tokens",
                schema: "ident",
                table: "user_tokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_roles",
                schema: "ident",
                table: "user_roles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_logins",
                schema: "ident",
                table: "user_logins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_claims",
                schema: "ident",
                table: "user_claims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role_claims",
                schema: "ident",
                table: "role_claims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refresh_tokens",
                schema: "ident",
                table: "refresh_tokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_tokens_users_UserId",
                schema: "ident",
                table: "refresh_tokens",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_role_claims_roles_RoleId",
                schema: "ident",
                table: "role_claims",
                column: "RoleId",
                principalSchema: "ident",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_claims_users_UserId",
                schema: "ident",
                table: "user_claims",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_logins_users_UserId",
                schema: "ident",
                table: "user_logins",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_roles_RoleId",
                schema: "ident",
                table: "user_roles",
                column: "RoleId",
                principalSchema: "ident",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_UserId",
                schema: "ident",
                table: "user_roles",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_tokens_users_UserId",
                schema: "ident",
                table: "user_tokens",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refresh_tokens_users_UserId",
                schema: "ident",
                table: "refresh_tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_role_claims_roles_RoleId",
                schema: "ident",
                table: "role_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_claims_users_UserId",
                schema: "ident",
                table: "user_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_user_logins_users_UserId",
                schema: "ident",
                table: "user_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_roles_RoleId",
                schema: "ident",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_UserId",
                schema: "ident",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_tokens_users_UserId",
                schema: "ident",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "ident",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                schema: "ident",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_tokens",
                schema: "ident",
                table: "user_tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_roles",
                schema: "ident",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_logins",
                schema: "ident",
                table: "user_logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_claims",
                schema: "ident",
                table: "user_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role_claims",
                schema: "ident",
                table: "role_claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refresh_tokens",
                schema: "ident",
                table: "refresh_tokens");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "ident",
                newName: "Users",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "roles",
                schema: "ident",
                newName: "Roles",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "user_tokens",
                schema: "ident",
                newName: "UserTokens",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "user_roles",
                schema: "ident",
                newName: "UserRoles",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "user_logins",
                schema: "ident",
                newName: "UserLogins",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "user_claims",
                schema: "ident",
                newName: "UserClaims",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "role_claims",
                schema: "ident",
                newName: "RoleClaims",
                newSchema: "ident");

            migrationBuilder.RenameTable(
                name: "refresh_tokens",
                schema: "ident",
                newName: "RefreshTokens",
                newSchema: "ident");

            migrationBuilder.RenameIndex(
                name: "IX_user_roles_RoleId",
                schema: "ident",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_logins_UserId",
                schema: "ident",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_claims_UserId",
                schema: "ident",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_role_claims_RoleId",
                schema: "ident",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_refresh_tokens_UserId",
                schema: "ident",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "ident",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "ident",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "ident",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "ident",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                schema: "ident",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                schema: "ident",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                schema: "ident",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "ident",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "ident",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "ident",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "ident",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                schema: "ident",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                schema: "ident",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "ident",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "ident",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "ident",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "ident",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "ident",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
