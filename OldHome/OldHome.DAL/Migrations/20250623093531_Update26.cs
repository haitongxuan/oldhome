using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationOutboundItems_MedicationSchedules_ScheduleId",
                table: "MedicationOutboundItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationOutboundItems_MedicineInventories_InventoryId",
                table: "MedicationOutboundItems");

            migrationBuilder.DropIndex(
                name: "IX_MedicationOutboundItems_InventoryId",
                table: "MedicationOutboundItems");

            migrationBuilder.DropIndex(
                name: "IX_MedicationOutboundItems_ScheduleId",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "RefusalReason",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "SpecialInstructions",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "MedicationOutboundItems");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "MedicationOutboundItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "MedicationOutboundItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpirationDate",
                table: "MedicationOutboundItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "MedicationOutboundItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "MedicationOutboundItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MedicationOutboundItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefusalReason",
                table: "MedicationOutboundItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "MedicationOutboundItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecialInstructions",
                table: "MedicationOutboundItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "MedicationOutboundItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                table: "MedicationOutboundItems",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutboundItems_InventoryId",
                table: "MedicationOutboundItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutboundItems_ScheduleId",
                table: "MedicationOutboundItems",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationOutboundItems_MedicationSchedules_ScheduleId",
                table: "MedicationOutboundItems",
                column: "ScheduleId",
                principalTable: "MedicationSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationOutboundItems_MedicineInventories_InventoryId",
                table: "MedicationOutboundItems",
                column: "InventoryId",
                principalTable: "MedicineInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
