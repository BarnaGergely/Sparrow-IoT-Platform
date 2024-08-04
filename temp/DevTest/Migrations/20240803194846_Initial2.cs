using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTest.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorValues_Sensors_SensorV5Id",
                table: "SensorValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorValues",
                table: "SensorValues");

            migrationBuilder.RenameTable(
                name: "SensorValues",
                newName: "Measure");

            migrationBuilder.RenameIndex(
                name: "IX_SensorValues_SensorV5Id",
                table: "Measure",
                newName: "IX_Measure_SensorV5Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measure",
                table: "Measure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measure_Sensors_SensorV5Id",
                table: "Measure",
                column: "SensorV5Id",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measure_Sensors_SensorV5Id",
                table: "Measure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measure",
                table: "Measure");

            migrationBuilder.RenameTable(
                name: "Measure",
                newName: "SensorValues");

            migrationBuilder.RenameIndex(
                name: "IX_Measure_SensorV5Id",
                table: "SensorValues",
                newName: "IX_SensorValues_SensorV5Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorValues",
                table: "SensorValues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorValues_Sensors_SensorV5Id",
                table: "SensorValues",
                column: "SensorV5Id",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
