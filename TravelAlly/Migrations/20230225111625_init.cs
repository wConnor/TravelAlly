using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAlly.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StationPassing",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "StationId", "TransportId" },
                values: new object[] { 4, null, new DateTime(2023, 2, 25, 10, 34, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "StationPassing",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "StationId", "TransportId" },
                values: new object[] { 5, new DateTime(2023, 2, 25, 15, 8, 0, 0, DateTimeKind.Unspecified), null, 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StationPassing",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StationPassing",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
