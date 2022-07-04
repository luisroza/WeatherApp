using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApp.Business.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humidity",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidity", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "Rainfall",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rainfall", x => x.TimeStamp);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.TimeStamp);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Humidity_TimeStamp",
                table: "Humidity",
                column: "TimeStamp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rainfall_TimeStamp",
                table: "Rainfall",
                column: "TimeStamp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_TimeStamp",
                table: "Temperatures",
                column: "TimeStamp",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humidity");

            migrationBuilder.DropTable(
                name: "Rainfall");

            migrationBuilder.DropTable(
                name: "Temperatures");
        }
    }
}
