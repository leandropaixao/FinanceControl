using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceControl.Web.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionInTableRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entries_UserId",
                schema: "public",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserId",
                schema: "public",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                schema: "public",
                table: "Entries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                schema: "public",
                table: "Accounts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entries_UserId",
                schema: "public",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_UserId",
                schema: "public",
                table: "Accounts");

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
        }
    }
}
