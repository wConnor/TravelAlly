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
                    Continent = table.Column<int>(type: "int", nullable: true)
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
                    { 1, 5, "United Kingdom", 51.507221999999999, -0.1275, "London" },
                    { 2, 5, "France", 48.864716000000001, 2.3490139999999999, "Paris" },
                    { 3, 5, "United Kingdom", 51.316366000000002, -0.55783300000000002, "Woking" },
                    { 4, 5, "United Kingdom", 51.26332, -1.090735, "Basingstoke" },
                    { 5, 5, "United Kingdom", 50.725555999999997, -3.5269439999999999, "Exeter" },
                    { 6, 5, "United Kingdom", 50.740690000000001, -3.4671699999999999, "Pinhoe" },
                    { 7, 5, "United Kingdom", 50.747, -3.4129999999999998, "Cranbrook (Devon)" },
                    { 8, 5, "United Kingdom", 50.798099999999998, -3.1924999999999999, "Honiton" },
                    { 9, 5, "United Kingdom", 50.7821, -2.9981, "Axminster" },
                    { 10, 5, "United Kingdom", 50.8842, -2.7953000000000001, "Crewkerne" },
                    { 11, 5, "United Kingdom", 50.924700000000001, -2.6132, "Yeovil" },
                    { 12, 5, "United Kingdom", 50.948900000000002, -2.5198, "Sherborne" },
                    { 13, 5, "United Kingdom", 51.0015, -2.4154, "Templecombe" },
                    { 14, 5, "United Kingdom", 51.038499999999999, -2.2768999999999999, "Gillingham (Dorset)" },
                    { 15, 5, "United Kingdom", 51.063899999999997, -2.0815999999999999, "Tisbury" },
                    { 16, 5, "United Kingdom", 51.069000000000003, -1.7951999999999999, "Salisbury" },
                    { 17, 5, "United Kingdom", 51.207900000000002, -1.4795, "Andover" }
                });

            migrationBuilder.InsertData(
                table: "Transport",
                columns: new[] { "Id", "Carrier", "OperatesOnDays", "RouteCode", "RouteType", "Type" },
                values: new object[,]
                {
                    { 1, "South Western Railway", 21, null, 0, 1 },
                    { 2, "Eurostar", 127, "", 1, 1 },
                    { 3, "South Western Railway", 127, "", 0, 1 }
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
                    { 5, 1, 4, 51.268419999999999, -1.08857, "Basingstoke Railway Station" },
                    { 6, 1, 5, 50.729215500000002, -3.5435702999999998, "Exeter St. Davids" },
                    { 7, 1, 6, 50.737789999999997, -3.4700799999999998, "Pinhoe Railway Station" },
                    { 8, 1, 7, 50.750010000000003, -3.4209700000000001, "Cranbrook Station" },
                    { 9, 1, 8, 50.796720000000001, -3.1869000000000001, "Honiton Railway Station" },
                    { 10, 1, 9, 50.77901, -3.00495, "Axminster Railway Station" },
                    { 11, 1, 10, 50.873570000000001, -2.7784399999999998, "Crewkerne Railway Station" },
                    { 12, 1, 11, 50.924790000000002, -2.61226, "Yeovil Junction" },
                    { 13, 1, 12, 50.943978999999999, -2.5129695999999999, "Sherborne Railway Station" },
                    { 14, 1, 13, 51.00159, -2.4172799999999999, "Templecombe Railway Station" },
                    { 15, 1, 14, 51.034089999999999, -2.2720799999999999, "Gillingham Railway Station" },
                    { 16, 1, 15, 51.061, -2.0787900000000001, "Tisbury Railway Station" },
                    { 17, 1, 16, 51.070549999999997, -1.8064499999999999, "Salisbury Railway Station" },
                    { 18, 1, 17, 51.211550000000003, -1.4927699999999999, "Andover Railway Station" },
                    { 19, 1, 1, 51.464458899999997, -0.17051839999999999, "Clapham Junction" },
                    { 20, 1, 5, 50.7270161, -3.5321297, "Exeter Central" }
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
                    { 5, new DateTime(2023, 2, 27, 15, 8, 0, 0, DateTimeKind.Unspecified), null, 2, 2 },
                    { 6, null, new DateTime(2023, 2, 27, 7, 25, 0, 0, DateTimeKind.Unspecified), 6, 3 },
                    { 7, new DateTime(2023, 2, 27, 7, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 7, 29, 0, 0, DateTimeKind.Unspecified), 20, 3 },
                    { 8, new DateTime(2023, 2, 27, 7, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 7, 34, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 9, new DateTime(2023, 2, 27, 7, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 7, 39, 0, 0, DateTimeKind.Unspecified), 8, 3 },
                    { 10, new DateTime(2023, 2, 27, 7, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 7, 52, 0, 0, DateTimeKind.Unspecified), 9, 3 },
                    { 11, new DateTime(2023, 2, 27, 8, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 8, 4, 0, 0, DateTimeKind.Unspecified), 10, 3 },
                    { 12, new DateTime(2023, 2, 27, 8, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 8, 17, 0, 0, DateTimeKind.Unspecified), 11, 3 },
                    { 13, new DateTime(2023, 2, 27, 8, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 8, 26, 0, 0, DateTimeKind.Unspecified), 12, 3 },
                    { 14, new DateTime(2023, 2, 27, 8, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 8, 35, 0, 0, DateTimeKind.Unspecified), 13, 3 },
                    { 15, new DateTime(2023, 2, 27, 8, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 8, 43, 0, 0, DateTimeKind.Unspecified), 14, 3 },
                    { 16, new DateTime(2023, 2, 27, 8, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 8, 51, 0, 0, DateTimeKind.Unspecified), 15, 3 },
                    { 17, new DateTime(2023, 2, 27, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 9, 1, 0, 0, DateTimeKind.Unspecified), 16, 3 },
                    { 18, new DateTime(2023, 2, 27, 9, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 9, 21, 0, 0, DateTimeKind.Unspecified), 17, 3 },
                    { 19, new DateTime(2023, 2, 27, 9, 37, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 9, 38, 0, 0, DateTimeKind.Unspecified), 18, 3 },
                    { 20, new DateTime(2023, 2, 27, 9, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 9, 57, 0, 0, DateTimeKind.Unspecified), 5, 3 },
                    { 21, new DateTime(2023, 2, 27, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 10, 17, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 22, new DateTime(2023, 2, 27, 10, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 27, 10, 37, 0, 0, DateTimeKind.Unspecified), 19, 3 },
                    { 23, new DateTime(2023, 2, 27, 10, 49, 0, 0, DateTimeKind.Unspecified), null, 3, 3 }
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
