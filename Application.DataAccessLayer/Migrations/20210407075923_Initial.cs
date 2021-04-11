using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingPass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsKeyPartner = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    PaymentOption = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParkingPassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_ParkingPass_ParkingPassId",
                        column: x => x.ParkingPassId,
                        principalTable: "ParkingPass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlateNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParkingPassId = table.Column<int>(type: "int", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_ParkingPass_ParkingPassId",
                        column: x => x.ParkingPassId,
                        principalTable: "ParkingPass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoggedParkingPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggedParkingPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoggedParkingPeriod_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CardId",
                table: "Car",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_LicensePlateNumber",
                table: "Car",
                column: "LicensePlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_ParkingPassId",
                table: "Car",
                column: "ParkingPassId",
                unique: true,
                filter: "[ParkingPassId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Card_Number",
                table: "Card",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_ParkingPassId",
                table: "Card",
                column: "ParkingPassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoggedParkingPeriod_CarId",
                table: "LoggedParkingPeriod",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_LoggedParkingPeriod_TransactionId",
                table: "LoggedParkingPeriod",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPass_Number",
                table: "ParkingPass",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoggedParkingPeriod");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "ParkingPass");
        }
    }
}
