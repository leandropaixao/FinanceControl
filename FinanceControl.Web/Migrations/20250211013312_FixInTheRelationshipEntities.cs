using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceControl.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixInTheRelationshipEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "Entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "Accounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                schema: "public",
                table: "Entries",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                schema: "public",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                schema: "public",
                table: "Accounts",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_UserId",
                schema: "public",
                table: "Entries",
                column: "UserId",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                schema: "public",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_UserId",
                schema: "public",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_UserId",
                schema: "public",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserId",
                schema: "public",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "Accounts");
        }
    }
}
