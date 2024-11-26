using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class JobApplicationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_OpenPositions_OpenPositionId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_OpenPositionId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "OpenPositionId",
                table: "JobApplications");

            migrationBuilder.AddColumn<string>(
                name: "OpenPosition",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 11, 6, 17, 36, DateTimeKind.Utc).AddTicks(2641));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenPosition",
                table: "JobApplications");

            migrationBuilder.AddColumn<int>(
                name: "OpenPositionId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 17, 45, 52, 272, DateTimeKind.Utc).AddTicks(7221));

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_OpenPositionId",
                table: "JobApplications",
                column: "OpenPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_OpenPositions_OpenPositionId",
                table: "JobApplications",
                column: "OpenPositionId",
                principalTable: "OpenPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
