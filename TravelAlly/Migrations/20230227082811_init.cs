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
                    RouteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RouteType = table.Column<int>(type: "int", nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatesOnDays = table.Column<int>(type: "int", nullable: true)
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
                    CityId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "StationPassing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationPassing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationPassing_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StationPassing_Transport_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Continent", "Country", "Lat", "Lon", "Name" },
                values: new object[,]
                {
                    { 1, "Europe", "United Kingdom", 51.507221999999999, -0.1275, "London" },
                    { 2, "Europe", "France", 48.864716000000001, 2.3490139999999999, "Paris" },
                    { 3, "Europe", "United Kingdom", 51.316366000000002, -0.55783300000000002, "Woking" },
                    { 4, "Europe", "United Kingdom", 51.26332, -1.090735, "Basingstoke" }
                });

            migrationBuilder.InsertData(
                table: "Transport",
                columns: new[] { "Id", "Carrier", "OperatesOnDays", "RouteCode", "RouteType", "Type" },
                values: new object[,]
                {
                    { 1, "South Western Railway", 21, null, 0, 1 },
                    { 2, "Eurostar", 127, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "AcceptsTypes", "CityId", "Lat", "Lon", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, 51.530000000000001, -0.125278, "St. Pancras International" },
                    { 2, 1, 2, 48.881110999999997, 2.3552780000000002, "Gare du Nord" },
                    { 3, 1, 1, 51.503100000000003, -0.1132, "London Waterloo" },
                    { 4, 1, 3, 51.319029999999998, -0.55598000000000003, "Woking Railway Station" },
                    { 5, 1, 4, 51.268419999999999, -1.08857, "Basingstoke Railway Station" }
                });

            migrationBuilder.InsertData(
                table: "StationPassing",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "StationId", "TransportId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 2, 27, 8, 45, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 2, new DateTime(2023, 2, 27, 9, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 9, 9, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 3, new DateTime(2023, 2, 27, 9, 41, 0, 0, DateTimeKind.Unspecified), null, 3, 1 },
                    { 4, null, new DateTime(2023, 2, 27, 10, 34, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, new DateTime(2023, 2, 27, 15, 8, 0, 0, DateTimeKind.Unspecified), null, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Station_CityId",
                table: "Station",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_StationPassing_StationId",
                table: "StationPassing",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_StationPassing_TransportId",
                table: "StationPassing",
                column: "TransportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationPassing");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
