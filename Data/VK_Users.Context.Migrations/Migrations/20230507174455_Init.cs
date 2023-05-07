using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VK_Users.Context.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_groups",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_groups", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "user_states",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_states", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateOnly>(type: "date", nullable: false),
                    user_group_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    user_state_uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.uid);
                    table.ForeignKey(
                        name: "FK_users_user_groups_user_group_uid",
                        column: x => x.user_group_uid,
                        principalTable: "user_groups",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_user_states_user_state_uid",
                        column: x => x.user_state_uid,
                        principalTable: "user_states",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_user_group_uid",
                table: "users",
                column: "user_group_uid");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_state_uid",
                table: "users",
                column: "user_state_uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_groups");

            migrationBuilder.DropTable(
                name: "user_states");
        }
    }
}
