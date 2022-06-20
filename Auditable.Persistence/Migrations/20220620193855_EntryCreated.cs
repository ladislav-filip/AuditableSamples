using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auditable.Persistence.Migrations
{
    public partial class EntryCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AuditEntries",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AuditEntries",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AuditEntries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AuditEntries");
        }
    }
}
