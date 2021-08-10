using Microsoft.EntityFrameworkCore.Migrations;

namespace FormatChanger.Migrations
{
    public partial class Changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedFields_SavedExports_FatherId",
                table: "SavedFields");

            migrationBuilder.DropIndex(
                name: "IX_SavedFields_FatherId",
                table: "SavedFields");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "SavedFields");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "SavedFields",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedFields_FatherId",
                table: "SavedFields",
                column: "FatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedFields_SavedExports_FatherId",
                table: "SavedFields",
                column: "FatherId",
                principalTable: "SavedExports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
