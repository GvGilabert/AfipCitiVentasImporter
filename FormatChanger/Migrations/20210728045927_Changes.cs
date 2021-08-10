using Microsoft.EntityFrameworkCore.Migrations;

namespace FormatChanger.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormatMappedField_Fields_FieldFromId",
                table: "FormatMappedField");

            migrationBuilder.DropForeignKey(
                name: "FK_FormatMappedField_Fields_FieldToId",
                table: "FormatMappedField");

            migrationBuilder.DropForeignKey(
                name: "FK_FormatMapper_Formats_FormatFromId",
                table: "FormatMapper");

            migrationBuilder.DropForeignKey(
                name: "FK_FormatMapper_Formats_FormatToId",
                table: "FormatMapper");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedFields_Fields_FieldId",
                table: "SavedFields");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_FormatMapper_FormatFromId",
                table: "FormatMapper");

            migrationBuilder.DropIndex(
                name: "IX_FormatMapper_FormatToId",
                table: "FormatMapper");

            migrationBuilder.DropColumn(
                name: "FormatFromId",
                table: "FormatMapper");

            migrationBuilder.DropColumn(
                name: "FormatToId",
                table: "FormatMapper");

            migrationBuilder.RenameColumn(
                name: "FieldId",
                table: "SavedFields",
                newName: "SavedRowId");

            migrationBuilder.RenameIndex(
                name: "IX_SavedFields_FieldId",
                table: "SavedFields",
                newName: "IX_SavedFields_SavedRowId");

            migrationBuilder.AddColumn<int>(
                name: "FieldFormatId",
                table: "SavedFields",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "SavedExports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormatId",
                table: "SavedExports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FieldFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FatherId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: true),
                    PaddingChar = table.Column<char>(type: "TEXT", nullable: true),
                    StringFormatter = table.Column<string>(type: "TEXT", nullable: true),
                    DefaultValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldFormats_Formats_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SavedExportId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedRow_SavedExports_SavedExportId",
                        column: x => x.SavedExportId,
                        principalTable: "SavedExports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedFields_FieldFormatId",
                table: "SavedFields",
                column: "FieldFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedExports_FormatId",
                table: "SavedExports",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldFormats_FatherId",
                table: "FieldFormats",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedRow_SavedExportId",
                table: "SavedRow",
                column: "SavedExportId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormatMappedField_FieldFormats_FieldFromId",
                table: "FormatMappedField",
                column: "FieldFromId",
                principalTable: "FieldFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormatMappedField_FieldFormats_FieldToId",
                table: "FormatMappedField",
                column: "FieldToId",
                principalTable: "FieldFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedExports_Formats_FormatId",
                table: "SavedExports",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedFields_FieldFormats_FieldFormatId",
                table: "SavedFields",
                column: "FieldFormatId",
                principalTable: "FieldFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedFields_SavedRow_SavedRowId",
                table: "SavedFields",
                column: "SavedRowId",
                principalTable: "SavedRow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormatMappedField_FieldFormats_FieldFromId",
                table: "FormatMappedField");

            migrationBuilder.DropForeignKey(
                name: "FK_FormatMappedField_FieldFormats_FieldToId",
                table: "FormatMappedField");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedExports_Formats_FormatId",
                table: "SavedExports");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedFields_FieldFormats_FieldFormatId",
                table: "SavedFields");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedFields_SavedRow_SavedRowId",
                table: "SavedFields");

            migrationBuilder.DropTable(
                name: "FieldFormats");

            migrationBuilder.DropTable(
                name: "SavedRow");

            migrationBuilder.DropIndex(
                name: "IX_SavedFields_FieldFormatId",
                table: "SavedFields");

            migrationBuilder.DropIndex(
                name: "IX_SavedExports_FormatId",
                table: "SavedExports");

            migrationBuilder.DropColumn(
                name: "FieldFormatId",
                table: "SavedFields");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "SavedExports");

            migrationBuilder.DropColumn(
                name: "FormatId",
                table: "SavedExports");

            migrationBuilder.RenameColumn(
                name: "SavedRowId",
                table: "SavedFields",
                newName: "FieldId");

            migrationBuilder.RenameIndex(
                name: "IX_SavedFields_SavedRowId",
                table: "SavedFields",
                newName: "IX_SavedFields_FieldId");

            migrationBuilder.AddColumn<int>(
                name: "FormatFromId",
                table: "FormatMapper",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormatToId",
                table: "FormatMapper",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DefaultValue = table.Column<string>(type: "TEXT", nullable: true),
                    FatherId = table.Column<int>(type: "INTEGER", nullable: true),
                    Length = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PaddingChar = table.Column<char>(type: "TEXT", nullable: true),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    StringFormatter = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Formats_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormatMapper_FormatFromId",
                table: "FormatMapper",
                column: "FormatFromId");

            migrationBuilder.CreateIndex(
                name: "IX_FormatMapper_FormatToId",
                table: "FormatMapper",
                column: "FormatToId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FatherId",
                table: "Fields",
                column: "FatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormatMappedField_Fields_FieldFromId",
                table: "FormatMappedField",
                column: "FieldFromId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormatMappedField_Fields_FieldToId",
                table: "FormatMappedField",
                column: "FieldToId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormatMapper_Formats_FormatFromId",
                table: "FormatMapper",
                column: "FormatFromId",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormatMapper_Formats_FormatToId",
                table: "FormatMapper",
                column: "FormatToId",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedFields_Fields_FieldId",
                table: "SavedFields",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
