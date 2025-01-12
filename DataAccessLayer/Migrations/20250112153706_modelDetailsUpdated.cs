using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class modelDetailsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltTitle",
                table: "ModelDetails");

            migrationBuilder.DropColumn(
                name: "BendStrength",
                table: "ModelDetails");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "ModelDetails");

            migrationBuilder.DropColumn(
                name: "SurfaceFinish",
                table: "ModelDetails");

            migrationBuilder.DropColumn(
                name: "SurfaceQuality",
                table: "ModelDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 12, 15, 37, 5, 139, DateTimeKind.Utc).AddTicks(1031));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                table: "ModelDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BendStrength",
                table: "ModelDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "ModelDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurfaceFinish",
                table: "ModelDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurfaceQuality",
                table: "ModelDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 29, 22, 23, 1, 35, DateTimeKind.Utc).AddTicks(6789));
        }
    }
}
