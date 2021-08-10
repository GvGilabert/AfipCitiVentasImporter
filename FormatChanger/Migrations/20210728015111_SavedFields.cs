using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormatChanger.Migrations
{
    public partial class SavedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedExports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SavedFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    FatherId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavedFields_SavedExports_FatherId",
                        column: x => x.FatherId,
                        principalTable: "SavedExports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedFields_FatherId",
                table: "SavedFields",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedFields_FieldId",
                table: "SavedFields",
                column: "FieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedFields");

            migrationBuilder.DropTable(
                name: "SavedExports");
        }
    }
}
