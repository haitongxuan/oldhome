using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "MedicationPrescriptionItems");

            migrationBuilder.DropColumn(
                name: "MedicationTimes",
                table: "MedicationPrescriptionItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "MedicationPrescriptionItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MedicationTimes",
                table: "MedicationPrescriptionItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
