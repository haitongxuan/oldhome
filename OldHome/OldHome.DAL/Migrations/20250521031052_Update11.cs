using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "MedicineInventories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInventories_ResidentId",
                table: "MedicineInventories",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineInventories_Residents_ResidentId",
                table: "MedicineInventories",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineInventories_Residents_ResidentId",
                table: "MedicineInventories");

            migrationBuilder.DropIndex(
                name: "IX_MedicineInventories_ResidentId",
                table: "MedicineInventories");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "MedicineInventories");
        }
    }
}
