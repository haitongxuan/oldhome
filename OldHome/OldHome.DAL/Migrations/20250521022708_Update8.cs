using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PackageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    QtyRemaining = table.Column<int>(type: "INTEGER", nullable: false),
                    QtyTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineInventories_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentBedChangeRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: true),
                    FromRoomId = table.Column<int>(type: "INTEGER", nullable: true),
                    FromBedId = table.Column<int>(type: "INTEGER", nullable: true),
                    ToRoomId = table.Column<int>(type: "INTEGER", nullable: true),
                    ToBedId = table.Column<int>(type: "INTEGER", nullable: true),
                    ChangeType = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    ChangeDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentBedChangeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentBedChangeRecords_Beds_FromBedId",
                        column: x => x.FromBedId,
                        principalTable: "Beds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidentBedChangeRecords_Beds_ToBedId",
                        column: x => x.ToBedId,
                        principalTable: "Beds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidentBedChangeRecords_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidentBedChangeRecords_Rooms_FromRoomId",
                        column: x => x.FromRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidentBedChangeRecords_Rooms_ToRoomId",
                        column: x => x.ToRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidentBedChangeRecords_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentMedicineInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    WarningThreshold = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentMedicineInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentMedicineInventories_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentMedicineInventories_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentMedicineInventories_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTransactionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineInventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationType = table.Column<int>(type: "INTEGER", nullable: false),
                    QtyChanged = table.Column<int>(type: "INTEGER", nullable: false),
                    Unit = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTransactionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineTransactionLogs_MedicineInventories_MedicineInventoryId",
                        column: x => x.MedicineInventoryId,
                        principalTable: "MedicineInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineTransactionLogs_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineTransactionLogs_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInventories_MedicineId",
                table: "MedicineInventories",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_MedicineId",
                table: "MedicineTransactionLogs",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_MedicineInventoryId",
                table: "MedicineTransactionLogs",
                column: "MedicineInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_ResidentId",
                table: "MedicineTransactionLogs",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedChangeRecords_CreatorId",
                table: "ResidentBedChangeRecords",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedChangeRecords_FromBedId",
                table: "ResidentBedChangeRecords",
                column: "FromBedId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedChangeRecords_FromRoomId",
                table: "ResidentBedChangeRecords",
                column: "FromRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedChangeRecords_ResidentId",
                table: "ResidentBedChangeRecords",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedChangeRecords_ToBedId",
                table: "ResidentBedChangeRecords",
                column: "ToBedId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedChangeRecords_ToRoomId",
                table: "ResidentBedChangeRecords",
                column: "ToRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedicineInventories_MedicineId",
                table: "ResidentMedicineInventories",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedicineInventories_OrgId",
                table: "ResidentMedicineInventories",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedicineInventories_ResidentId",
                table: "ResidentMedicineInventories",
                column: "ResidentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineTransactionLogs");

            migrationBuilder.DropTable(
                name: "ResidentBedChangeRecords");

            migrationBuilder.DropTable(
                name: "ResidentMedicineInventories");

            migrationBuilder.DropTable(
                name: "MedicineInventories");
        }
    }
}
