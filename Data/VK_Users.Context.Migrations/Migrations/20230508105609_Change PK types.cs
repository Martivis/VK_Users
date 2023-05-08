using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VK_Users.Context.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ChangePKtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_user_groups_user_group_uid",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_states_user_state_uid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_user_group_uid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_user_state_uid",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_states",
                table: "user_states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_groups",
                table: "user_groups");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "user_states");

            migrationBuilder.DropColumn(
                name: "uid",
                table: "user_groups");

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserStateId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "user_states",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "user_groups",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_states",
                table: "user_states",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_groups",
                table: "user_groups",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserGroupId",
                table: "users",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserStateId",
                table: "users",
                column: "UserStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_groups_UserGroupId",
                table: "users",
                column: "UserGroupId",
                principalTable: "user_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_states_UserStateId",
                table: "users",
                column: "UserStateId",
                principalTable: "user_states",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_user_groups_UserGroupId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_states_UserStateId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserGroupId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserStateId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_states",
                table: "user_states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_groups",
                table: "user_groups");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserStateId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "id",
                table: "user_states");

            migrationBuilder.DropColumn(
                name: "id",
                table: "user_groups");

            migrationBuilder.AddColumn<Guid>(
                name: "uid",
                table: "user_states",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "uid",
                table: "user_groups",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_states",
                table: "user_states",
                column: "uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_groups",
                table: "user_groups",
                column: "uid");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_group_uid",
                table: "users",
                column: "user_group_uid");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_state_uid",
                table: "users",
                column: "user_state_uid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_groups_user_group_uid",
                table: "users",
                column: "user_group_uid",
                principalTable: "user_groups",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_states_user_state_uid",
                table: "users",
                column: "user_state_uid",
                principalTable: "user_states",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
