using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeCarrosAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARS",
                columns: table => new
                {
                    CAR_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MODEL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    BRAND = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    YEAR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DAILY_RATE = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARS", x => x.CAR_ID);
                });

            migrationBuilder.CreateTable(
                name: "RENTALS",
                columns: table => new
                {
                    RENTAL_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CAR_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RENTALS", x => x.RENTAL_ID);
                    table.ForeignKey(
                        name: "FK_RENTALS_CARS_CAR_ID",
                        column: x => x.CAR_ID,
                        principalTable: "CARS",
                        principalColumn: "CAR_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RENTALS_CAR_ID",
                table: "RENTALS",
                column: "CAR_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RENTALS");

            migrationBuilder.DropTable(
                name: "CARS");
        }
    }
}
