using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auditable.Persistence.Migrations
{
    public partial class EntryRelationNameNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RelationName",
                table: "AuditEntries",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuditEntries",
                keyColumn: "RelationName",
                keyValue: null,
                column: "RelationName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RelationName",
                table: "AuditEntries",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
