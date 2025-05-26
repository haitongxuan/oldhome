using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Residents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrgAreaId",
                table: "Residents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Residents_OrgAreaId",
                table: "Residents",
                column: "OrgAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_OrgAreas_OrgAreaId",
                table: "Residents",
                column: "OrgAreaId",
                principalTable: "OrgAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residents_OrgAreas_OrgAreaId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_OrgAreaId",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "OrgAreaId",
                table: "Residents");
        }
    }
}
