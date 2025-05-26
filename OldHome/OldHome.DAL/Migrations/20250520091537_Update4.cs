using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentMedications_Users_CreatorId",
                table: "ResidentMedications");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "ResidentMedications",
                newName: "OrgId");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentMedications_CreatorId",
                table: "ResidentMedications",
                newName: "IX_ResidentMedications_OrgId");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Medicines",
                newName: "QtyPerPackage");

            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "Residents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ResidentMedications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ResidentMedications",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ResidentMedications",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ResidentMedications",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ResidentMedicationItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ResidentMedicationItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ResidentMedicationItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "ResidentMedicationItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ResidentMedicationItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ResidentMedicationItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalNumber",
                table: "Medicines",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                table: "Medicines",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MinUnit",
                table: "Medicines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageUnit",
                table: "Medicines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Residents_BedId",
                table: "Residents",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_RoomId",
                table: "Residents",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedicationItems_OrgId",
                table: "ResidentMedicationItems",
                column: "OrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentMedicationItems_Orgs_OrgId",
                table: "ResidentMedicationItems",
                column: "OrgId",
                principalTable: "Orgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentMedications_Orgs_OrgId",
                table: "ResidentMedications",
                column: "OrgId",
                principalTable: "Orgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Beds_BedId",
                table: "Residents",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Rooms_RoomId",
                table: "Residents",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentMedicationItems_Orgs_OrgId",
                table: "ResidentMedicationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentMedications_Orgs_OrgId",
                table: "ResidentMedications");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Beds_BedId",
                table: "Residents");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Rooms_RoomId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_BedId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_RoomId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_ResidentMedicationItems_OrgId",
                table: "ResidentMedicationItems");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ResidentMedications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ResidentMedications");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ResidentMedications");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ResidentMedications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ResidentMedicationItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ResidentMedicationItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ResidentMedicationItems");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "ResidentMedicationItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ResidentMedicationItems");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ResidentMedicationItems");

            migrationBuilder.DropColumn(
                name: "ApprovalNumber",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "BarCode",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MinUnit",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "PackageUnit",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "OrgId",
                table: "ResidentMedications",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentMedications_OrgId",
                table: "ResidentMedications",
                newName: "IX_ResidentMedications_CreatorId");

            migrationBuilder.RenameColumn(
                name: "QtyPerPackage",
                table: "Medicines",
                newName: "Unit");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentMedications_Users_CreatorId",
                table: "ResidentMedications",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
