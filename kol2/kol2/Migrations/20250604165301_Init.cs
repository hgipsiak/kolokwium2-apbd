using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kol2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    TemperatureCelsius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Washing_Machine",
                columns: table => new
                {
                    WashingMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Washing_Machine", x => x.WashingMachineId);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_History",
                columns: table => new
                {
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_History", x => new { x.AvailableProgramId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Purchase_History_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Available_Program",
                columns: table => new
                {
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WashingMachineId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available_Program", x => x.AvailableProgramId);
                    table.ForeignKey(
                        name: "FK_Available_Program_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Available_Program_Washing_Machine_WashingMachineId",
                        column: x => x.WashingMachineId,
                        principalTable: "Washing_Machine",
                        principalColumn: "WashingMachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Available_ProgramPurchase_History",
                columns: table => new
                {
                    AvailableProgramsAvailableProgramId = table.Column<int>(type: "int", nullable: false),
                    PurchaseHistoriesAvailableProgramId = table.Column<int>(type: "int", nullable: false),
                    PurchaseHistoriesCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available_ProgramPurchase_History", x => new { x.AvailableProgramsAvailableProgramId, x.PurchaseHistoriesAvailableProgramId, x.PurchaseHistoriesCustomerId });
                    table.ForeignKey(
                        name: "FK_Available_ProgramPurchase_History_Available_Program_AvailableProgramsAvailableProgramId",
                        column: x => x.AvailableProgramsAvailableProgramId,
                        principalTable: "Available_Program",
                        principalColumn: "AvailableProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Available_ProgramPurchase_History_Purchase_History_PurchaseHistoriesAvailableProgramId_PurchaseHistoriesCustomerId",
                        columns: x => new { x.PurchaseHistoriesAvailableProgramId, x.PurchaseHistoriesCustomerId },
                        principalTable: "Purchase_History",
                        principalColumns: new[] { "AvailableProgramId", "CustomerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "123456789" },
                    { 2, "Jane", "Doe", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "ProgramId", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 60, "Program1", 60 },
                    { 2, 40, "Program2", 30 },
                    { 3, 30, "Program3", 20 }
                });

            migrationBuilder.InsertData(
                table: "Washing_Machine",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 20m, "abcd" },
                    { 2, 30m, "dafa" },
                    { 3, 40m, "iorem" }
                });

            migrationBuilder.InsertData(
                table: "Available_Program",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashingMachineId" },
                values: new object[,]
                {
                    { 1, 20m, 1, 2 },
                    { 2, 40m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Purchase_History",
                columns: new[] { "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Available_Program_ProgramId",
                table: "Available_Program",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Available_Program_WashingMachineId",
                table: "Available_Program",
                column: "WashingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Available_ProgramPurchase_History_PurchaseHistoriesAvailableProgramId_PurchaseHistoriesCustomerId",
                table: "Available_ProgramPurchase_History",
                columns: new[] { "PurchaseHistoriesAvailableProgramId", "PurchaseHistoriesCustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_History_CustomerId",
                table: "Purchase_History",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Available_ProgramPurchase_History");

            migrationBuilder.DropTable(
                name: "Available_Program");

            migrationBuilder.DropTable(
                name: "Purchase_History");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Washing_Machine");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
