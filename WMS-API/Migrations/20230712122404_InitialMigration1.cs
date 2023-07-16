using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "binStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WasteStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_binStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wCollectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wCollectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longtitude = table.Column<double>(type: "double precision", nullable: false),
                    AreaCode = table.Column<string>(type: "text", nullable: false),
                    BinSize = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    binStatusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bins_binStatuses_binStatusId",
                        column: x => x.binStatusId,
                        principalTable: "binStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "binStatuses",
                columns: new[] { "Id", "WasteStatus" },
                values: new object[,]
                {
                    { new Guid("9d8c0470-1143-4a7d-b793-2ff85ad3d6df"), "Bin is Half-filled" },
                    { new Guid("ae6638f6-2a49-44ee-8dee-a906c99e5f0c"), "Bin if Full" },
                    { new Guid("d6de91d5-d9c3-4f8a-bc16-8d844779a715"), "Bin Is Empty" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bins_binStatusId",
                table: "bins",
                column: "binStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bins");

            migrationBuilder.DropTable(
                name: "wCollectors");

            migrationBuilder.DropTable(
                name: "binStatuses");
        }
    }
}
