using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class modelimageupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelImages_ModelDetails_ModelDetailId",
                table: "ModelImages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ModelImages");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelImages_ModelDetails_ModelDetailId",
                table: "ModelImages",
                column: "ModelDetailId",
                principalTable: "ModelDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelImages_ModelDetails_ModelDetailId",
                table: "ModelImages");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ModelImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelImages_ModelDetails_ModelDetailId",
                table: "ModelImages",
                column: "ModelDetailId",
                principalTable: "ModelDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
