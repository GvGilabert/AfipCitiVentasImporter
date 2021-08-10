using Microsoft.EntityFrameworkCore.Migrations;

namespace FormatChanger.Migrations
{
    public partial class MappedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormatMapper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FormatFromId = table.Column<int>(type: "INTEGER", nullable: true),
                    FormatToId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatMapper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormatMapper_Formats_FormatFromId",
                        column: x => x.FormatFromId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormatMapper_Formats_FormatToId",
                        column: x => x.FormatToId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormatMappedField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldFromId = table.Column<int>(type: "INTEGER", nullable: true),
                    FieldToId = table.Column<int>(type: "INTEGER", nullable: true),
                    FatherId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatMappedField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormatMappedField_Fields_FieldFromId",
                        column: x => x.FieldFromId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormatMappedField_Fields_FieldToId",
                        column: x => x.FieldToId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormatMappedField_FormatMapper_FatherId",
                        column: x => x.FatherId,
                        principalTable: "FormatMapper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormatMappedField_FatherId",
                table: "FormatMappedField",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_FormatMappedField_FieldFromId",
                table: "FormatMappedField",
                column: "FieldFromId");

            migrationBuilder.CreateIndex(
                name: "IX_FormatMappedField_FieldToId",
                table: "FormatMappedField",
                column: "FieldToId");

            migrationBuilder.CreateIndex(
                name: "IX_FormatMapper_FormatFromId",
                table: "FormatMapper",
                column: "FormatFromId");

            migrationBuilder.CreateIndex(
                name: "IX_FormatMapper_FormatToId",
                table: "FormatMapper",
                column: "FormatToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormatMappedField");

            migrationBuilder.DropTable(
                name: "FormatMapper");
        }
    }
}
