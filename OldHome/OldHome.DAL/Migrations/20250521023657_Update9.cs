using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "MedicineTransactionLogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "MedicineInventories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_OrgId",
                table: "MedicineTransactionLogs",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInventories_OrgId",
                table: "MedicineInventories",
                column: "OrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineInventories_Orgs_OrgId",
                table: "MedicineInventories",
                column: "OrgId",
                principalTable: "Orgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineTransactionLogs_Orgs_OrgId",
                table: "MedicineTransactionLogs",
                column: "OrgId",
                principalTable: "Orgs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineInventories_Orgs_OrgId",
                table: "MedicineInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineTransactionLogs_Orgs_OrgId",
                table: "MedicineTransactionLogs");

            migrationBuilder.DropIndex(
                name: "IX_MedicineTransactionLogs_OrgId",
                table: "MedicineTransactionLogs");

            migrationBuilder.DropIndex(
                name: "IX_MedicineInventories_OrgId",
                table: "MedicineInventories");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedicineTransactionLogs");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedicineInventories");
        }
    }
}
