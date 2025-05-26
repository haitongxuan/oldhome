using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Beds_OrgAreaId",
                table: "Beds",
                column: "OrgAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_OrgAreas_OrgAreaId",
                table: "Beds",
                column: "OrgAreaId",
                principalTable: "OrgAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_OrgAreas_OrgAreaId",
                table: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_OrgAreaId",
                table: "Beds");
        }
    }
}
