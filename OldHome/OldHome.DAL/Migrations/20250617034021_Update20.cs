using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPrescriptions_Staffs_DoctorId",
                table: "MedicationPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPrescriptions_Staffs_ReviewedById",
                table: "MedicationPrescriptions");

            migrationBuilder.DropIndex(
                name: "IX_MedicationPrescriptions_DoctorId",
                table: "MedicationPrescriptions");

            migrationBuilder.DropIndex(
                name: "IX_MedicationPrescriptions_ReviewedById",
                table: "MedicationPrescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "MedicationPrescriptions");

            migrationBuilder.DropColumn(
                name: "ReviewedById",
                table: "MedicationPrescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "MedicationPrescriptions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewedById",
                table: "MedicationPrescriptions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_DoctorId",
                table: "MedicationPrescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_ReviewedById",
                table: "MedicationPrescriptions",
                column: "ReviewedById");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPrescriptions_Staffs_DoctorId",
                table: "MedicationPrescriptions",
                column: "DoctorId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPrescriptions_Staffs_ReviewedById",
                table: "MedicationPrescriptions",
                column: "ReviewedById",
                principalTable: "Staffs",
                principalColumn: "Id");
        }
    }
}
