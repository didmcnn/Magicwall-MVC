using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class modeldetailsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "ModelPageItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModelDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thickness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Measurements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurfaceFinish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsableEnviroments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FireResistance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurfaceQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BendStrength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimentionTolerance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeatResistance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThicknesTolerance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelPageItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelDetails_ModelPageItems_ModelPageItemId",
                        column: x => x.ModelPageItemId,
                        principalTable: "ModelPageItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelImages_ModelDetails_ModelDetailId",
                        column: x => x.ModelDetailId,
                        principalTable: "ModelDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 19, 27, 24, 639, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.CreateIndex(
                name: "IX_ModelDetails_ModelPageItemId",
                table: "ModelDetails",
                column: "ModelPageItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelImages_ModelDetailId",
                table: "ModelImages",
                column: "ModelDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelImages");

            migrationBuilder.DropTable(
                name: "ModelDetails");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "ModelPageItems");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 11, 6, 17, 36, DateTimeKind.Utc).AddTicks(2641));
        }
    }
}
