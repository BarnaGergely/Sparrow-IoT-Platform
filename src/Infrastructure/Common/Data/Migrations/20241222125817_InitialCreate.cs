using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Kind = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeasurementTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReceptionTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Kind = table.Column<int>(type: "INTEGER", nullable: false),
                    SensorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Device 1" },
                    { 2, "Device 2" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "DeviceId", "Kind", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, "Sensor 1" },
                    { 2, 1, 2, "Sensor 2" },
                    { 3, 2, 3, "Sensor 3" }
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Kind", "MeasurementTime", "ReceptionTime", "SensorId", "Value" },
                values: new object[,]
                {
                    { 1, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 24.799999237060547 },
                    { 2, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12.0 },
                    { 3, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.47999998927116394 },
                    { 4, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.8970000147819519 },
                    { 5, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 12.0 },
                    { 6, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 19876.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_SensorId",
                table: "Measurements",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_DeviceId",
                table: "Sensors",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
