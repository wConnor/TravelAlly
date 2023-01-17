using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAlly.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptsTypes = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Station_Transport_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transport",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Continent", "Country", "Lat", "Lon", "Name" },
                values: new object[] { 1, "Europe", "England", 51.507221999999999, -0.1275, "London" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Continent", "Country", "Lat", "Lon", "Name" },
                values: new object[] { 2, "Europe", "France", 48.864716000000001, 2.3490139999999999, "Paris" });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "AcceptsTypes", "CityId", "Lat", "Lon", "Name", "TransportId" },
                values: new object[] { 1, 1, 1, 51.530000000000001, -0.125278, "St. Pancras International", null });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "AcceptsTypes", "CityId", "Lat", "Lon", "Name", "TransportId" },
                values: new object[] { 2, 1, 2, 48.881110999999997, 2.3552780000000002, "Gare du Nord", null });

            migrationBuilder.CreateIndex(
                name: "IX_Station_CityId",
                table: "Station",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_TransportId",
                table: "Station",
                column: "TransportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Transport");
        }
    }
}
