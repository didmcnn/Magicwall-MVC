using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class entitiesEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Catalogs");

            migrationBuilder.RenameColumn(
                name: "MapLocation",
                table: "Contacts",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "ContactSurname",
                table: "Contacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ContactMessage",
                table: "Contacts",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "Contacts",
                newName: "Email");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 17, 45, 52, 272, DateTimeKind.Utc).AddTicks(7221));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Contacts",
                newName: "MapLocation");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "ContactSurname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Contacts",
                newName: "ContactMessage");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contacts",
                newName: "ContactEmail");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 21, 15, 49, 529, DateTimeKind.Utc).AddTicks(1031));
        }
    }
}
