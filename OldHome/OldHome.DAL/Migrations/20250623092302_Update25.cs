using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbound_Orgs_OrgId",
                table: "InventoryOutbound");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbound_Residents_ResidentId",
                table: "InventoryOutbound");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbound_Users_ApprovedById",
                table: "InventoryOutbound");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbound_Users_OutboundById",
                table: "InventoryOutbound");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbound_Users_RequesterId",
                table: "InventoryOutbound");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutboundItem_InventoryOutbound_OutboundId",
                table: "InventoryOutboundItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutboundItem_MedicineInventories_InventoryId",
                table: "InventoryOutboundItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutboundItem_Medicines_MedicineId",
                table: "InventoryOutboundItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationSchedules_InventoryOutboundItem_OutboundItemId",
                table: "MedicationSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryOutboundItem",
                table: "InventoryOutboundItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryOutbound",
                table: "InventoryOutbound");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOutbound_ResidentId",
                table: "InventoryOutbound");

            migrationBuilder.DropColumn(
                name: "PreparedTime",
                table: "MedicationOutbounds");

            migrationBuilder.DropColumn(
                name: "ProviderInfo",
                table: "InventoryInbounds");

            migrationBuilder.DropColumn(
                name: "ProviderRelationship",
                table: "InventoryInbounds");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "InventoryInboundItems");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "InventoryOutbound");

            migrationBuilder.RenameTable(
                name: "InventoryOutboundItem",
                newName: "InventoryOutboundItems");

            migrationBuilder.RenameTable(
                name: "InventoryOutbound",
                newName: "InventoryOutbounds");

            migrationBuilder.RenameColumn(
                name: "SourceDetails",
                table: "InventoryInbounds",
                newName: "SourceInfo");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutboundItem_OutboundId",
                table: "InventoryOutboundItems",
                newName: "IX_InventoryOutboundItems_OutboundId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutboundItem_MedicineId",
                table: "InventoryOutboundItems",
                newName: "IX_InventoryOutboundItems_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutboundItem_InventoryId",
                table: "InventoryOutboundItems",
                newName: "IX_InventoryOutboundItems_InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbound_RequesterId",
                table: "InventoryOutbounds",
                newName: "IX_InventoryOutbounds_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbound_OutboundById",
                table: "InventoryOutbounds",
                newName: "IX_InventoryOutbounds_OutboundById");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbound_OrgId",
                table: "InventoryOutbounds",
                newName: "IX_InventoryOutbounds_OrgId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbound_ApprovedById",
                table: "InventoryOutbounds",
                newName: "IX_InventoryOutbounds_ApprovedById");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyRemaining",
                table: "MedicineInventories",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "IsFromPublicInventory",
                table: "MedicationOutbounds",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "RequestedQuantity",
                table: "InventoryOutboundItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualQuantity",
                table: "InventoryOutboundItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "InventoryOutboundItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryOutboundItems",
                table: "InventoryOutboundItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryOutbounds",
                table: "InventoryOutbounds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutboundItems_ResidentId",
                table: "InventoryOutboundItems",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutboundItems_InventoryOutbounds_OutboundId",
                table: "InventoryOutboundItems",
                column: "OutboundId",
                principalTable: "InventoryOutbounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutboundItems_MedicineInventories_InventoryId",
                table: "InventoryOutboundItems",
                column: "InventoryId",
                principalTable: "MedicineInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutboundItems_Medicines_MedicineId",
                table: "InventoryOutboundItems",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutboundItems_Residents_ResidentId",
                table: "InventoryOutboundItems",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbounds_Orgs_OrgId",
                table: "InventoryOutbounds",
                column: "OrgId",
                principalTable: "Orgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbounds_Users_ApprovedById",
                table: "InventoryOutbounds",
                column: "ApprovedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbounds_Users_OutboundById",
                table: "InventoryOutbounds",
                column: "OutboundById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbounds_Users_RequesterId",
                table: "InventoryOutbounds",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationSchedules_InventoryOutboundItems_OutboundItemId",
                table: "MedicationSchedules",
                column: "OutboundItemId",
                principalTable: "InventoryOutboundItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutboundItems_InventoryOutbounds_OutboundId",
                table: "InventoryOutboundItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutboundItems_MedicineInventories_InventoryId",
                table: "InventoryOutboundItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutboundItems_Medicines_MedicineId",
                table: "InventoryOutboundItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutboundItems_Residents_ResidentId",
                table: "InventoryOutboundItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbounds_Orgs_OrgId",
                table: "InventoryOutbounds");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbounds_Users_ApprovedById",
                table: "InventoryOutbounds");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbounds_Users_OutboundById",
                table: "InventoryOutbounds");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOutbounds_Users_RequesterId",
                table: "InventoryOutbounds");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationSchedules_InventoryOutboundItems_OutboundItemId",
                table: "MedicationSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryOutbounds",
                table: "InventoryOutbounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryOutboundItems",
                table: "InventoryOutboundItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOutboundItems_ResidentId",
                table: "InventoryOutboundItems");

            migrationBuilder.DropColumn(
                name: "IsFromPublicInventory",
                table: "MedicationOutbounds");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "InventoryOutboundItems");

            migrationBuilder.RenameTable(
                name: "InventoryOutbounds",
                newName: "InventoryOutbound");

            migrationBuilder.RenameTable(
                name: "InventoryOutboundItems",
                newName: "InventoryOutboundItem");

            migrationBuilder.RenameColumn(
                name: "SourceInfo",
                table: "InventoryInbounds",
                newName: "SourceDetails");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbounds_RequesterId",
                table: "InventoryOutbound",
                newName: "IX_InventoryOutbound_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbounds_OutboundById",
                table: "InventoryOutbound",
                newName: "IX_InventoryOutbound_OutboundById");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbounds_OrgId",
                table: "InventoryOutbound",
                newName: "IX_InventoryOutbound_OrgId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutbounds_ApprovedById",
                table: "InventoryOutbound",
                newName: "IX_InventoryOutbound_ApprovedById");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutboundItems_OutboundId",
                table: "InventoryOutboundItem",
                newName: "IX_InventoryOutboundItem_OutboundId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutboundItems_MedicineId",
                table: "InventoryOutboundItem",
                newName: "IX_InventoryOutboundItem_MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOutboundItems_InventoryId",
                table: "InventoryOutboundItem",
                newName: "IX_InventoryOutboundItem_InventoryId");

            migrationBuilder.AlterColumn<int>(
                name: "QtyRemaining",
                table: "MedicineInventories",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreparedTime",
                table: "MedicationOutbounds",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProviderInfo",
                table: "InventoryInbounds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderRelationship",
                table: "InventoryInbounds",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "InventoryInboundItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "InventoryOutbound",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestedQuantity",
                table: "InventoryOutboundItem",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ActualQuantity",
                table: "InventoryOutboundItem",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryOutbound",
                table: "InventoryOutbound",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryOutboundItem",
                table: "InventoryOutboundItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbound_ResidentId",
                table: "InventoryOutbound",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbound_Orgs_OrgId",
                table: "InventoryOutbound",
                column: "OrgId",
                principalTable: "Orgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbound_Residents_ResidentId",
                table: "InventoryOutbound",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbound_Users_ApprovedById",
                table: "InventoryOutbound",
                column: "ApprovedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbound_Users_OutboundById",
                table: "InventoryOutbound",
                column: "OutboundById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutbound_Users_RequesterId",
                table: "InventoryOutbound",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutboundItem_InventoryOutbound_OutboundId",
                table: "InventoryOutboundItem",
                column: "OutboundId",
                principalTable: "InventoryOutbound",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutboundItem_MedicineInventories_InventoryId",
                table: "InventoryOutboundItem",
                column: "InventoryId",
                principalTable: "MedicineInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOutboundItem_Medicines_MedicineId",
                table: "InventoryOutboundItem",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationSchedules_InventoryOutboundItem_OutboundItemId",
                table: "MedicationSchedules",
                column: "OutboundItemId",
                principalTable: "InventoryOutboundItem",
                principalColumn: "Id");
        }
    }
}
