using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryInbounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InboundNumber = table.Column<string>(type: "TEXT", nullable: false),
                    InboundType = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceType = table.Column<int>(type: "INTEGER", nullable: false),
                    InboundDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    SourceDetails = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderInfo = table.Column<string>(type: "TEXT", nullable: true),
                    ProviderRelationship = table.Column<int>(type: "INTEGER", nullable: true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: true),
                    PurchaseReference = table.Column<string>(type: "TEXT", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckedById = table.Column<int>(type: "INTEGER", nullable: true),
                    CheckedDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    InboundById = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryInbounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryInbounds_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryInbounds_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryInbounds_Users_CheckedById",
                        column: x => x.CheckedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryInbounds_Users_InboundById",
                        column: x => x.InboundById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryOutbound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutboundNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OutboundType = table.Column<int>(type: "INTEGER", nullable: false),
                    OutboundDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    RequesterId = table.Column<int>(type: "INTEGER", nullable: true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: true),
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ApprovedById = table.Column<int>(type: "INTEGER", nullable: true),
                    ApprovedDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    OutboundById = table.Column<int>(type: "INTEGER", nullable: true),
                    ReceiverSignature = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOutbound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOutbound_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOutbound_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOutbound_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOutbound_Users_OutboundById",
                        column: x => x.OutboundById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOutbound_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryStocktakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StocktakeNumber = table.Column<string>(type: "TEXT", nullable: false),
                    StocktakeType = table.Column<int>(type: "INTEGER", nullable: false),
                    StocktakeDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ScopeDescription = table.Column<string>(type: "TEXT", nullable: false),
                    StocktakePersons = table.Column<string>(type: "TEXT", nullable: false),
                    SupervisorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalDifferenceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStocktakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryStocktakes_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryStocktakes_Users_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationOutbounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutboundNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OutboundDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    MedicineTime = table.Column<int>(type: "INTEGER", nullable: false),
                    OutboundType = table.Column<int>(type: "INTEGER", nullable: false),
                    PharmacistId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckedById = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    PreparedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DispensedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TotalItemCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationOutbounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationOutbounds_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationOutbounds_Staffs_CheckedById",
                        column: x => x.CheckedById,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationOutbounds_Staffs_PharmacistId",
                        column: x => x.PharmacistId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationPrescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriptionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    PrescriptionType = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Diagnosis = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewedById = table.Column<int>(type: "INTEGER", nullable: true),
                    ReviewedDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPrescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptions_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptions_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptions_Staffs_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptions_Staffs_ReviewedById",
                        column: x => x.ReviewedById,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FamilyMedicineDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeliveryNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DeliveryPersonName = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryPersonPhone = table.Column<string>(type: "TEXT", nullable: false),
                    RelationshipToResident = table.Column<int>(type: "INTEGER", nullable: false),
                    IdentityCardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ReceivedById = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceivedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    InboundId = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMedicineDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMedicineDeliveries_InventoryInbounds_InboundId",
                        column: x => x.InboundId,
                        principalTable: "InventoryInbounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FamilyMedicineDeliveries_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMedicineDeliveries_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMedicineDeliveries_Users_ReceivedById",
                        column: x => x.ReceivedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryInboundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InboundId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ProductionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PackageQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StorageLocation = table.Column<string>(type: "TEXT", nullable: false),
                    InventoryType = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckedQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    CheckStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckNotes = table.Column<string>(type: "TEXT", nullable: true),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryInboundItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryInboundItems_InventoryInbounds_InboundId",
                        column: x => x.InboundId,
                        principalTable: "InventoryInbounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryInboundItems_MedicineInventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "MedicineInventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryInboundItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryOutboundItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutboundId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RequestedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ActualQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOutboundItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOutboundItem_InventoryOutbound_OutboundId",
                        column: x => x.OutboundId,
                        principalTable: "InventoryOutbound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOutboundItem_MedicineInventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "MedicineInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOutboundItem_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryStocktakeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StocktakeId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BookQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ActualQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DifferenceQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DifferenceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DifferenceReason = table.Column<string>(type: "TEXT", nullable: true),
                    TreatmentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStocktakeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryStocktakeItems_InventoryStocktakes_StocktakeId",
                        column: x => x.StocktakeId,
                        principalTable: "InventoryStocktakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryStocktakeItems_MedicineInventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "MedicineInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryStocktakeItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationPrescriptionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    Dosage = table.Column<string>(type: "TEXT", nullable: false),
                    DosageAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    TimesPerDay = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicationTimes = table.Column<string>(type: "TEXT", nullable: false),
                    MedicationType = table.Column<int>(type: "INTEGER", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "TEXT", nullable: false),
                    IsPRN = table.Column<bool>(type: "INTEGER", nullable: false),
                    PRNCondition = table.Column<string>(type: "TEXT", nullable: true),
                    MaxDailyDose = table.Column<decimal>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPrescriptionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptionItems_MedicationPrescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "MedicationPrescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationPrescriptionItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMedicineDeliveryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeliveryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineName = table.Column<string>(type: "TEXT", nullable: false),
                    Specification = table.Column<string>(type: "TEXT", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ProductionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    PurchaseLocation = table.Column<string>(type: "TEXT", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CheckStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckNotes = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMedicineDeliveryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMedicineDeliveryItems_FamilyMedicineDeliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "FamilyMedicineDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMedicineDeliveryItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScheduleNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriptionItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ScheduleTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    MedicineTime = table.Column<int>(type: "INTEGER", nullable: false),
                    PlannedDosage = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActualDosage = table.Column<decimal>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleType = table.Column<int>(type: "INTEGER", nullable: false),
                    ExecutedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExecutedById = table.Column<int>(type: "INTEGER", nullable: true),
                    OutboundItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    SkipReason = table.Column<string>(type: "TEXT", nullable: true),
                    DelayReason = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationSchedules_InventoryOutboundItem_OutboundItemId",
                        column: x => x.OutboundItemId,
                        principalTable: "InventoryOutboundItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationSchedules_MedicationPrescriptionItems_PrescriptionItemId",
                        column: x => x.PrescriptionItemId,
                        principalTable: "MedicationPrescriptionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationSchedules_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationSchedules_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationSchedules_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationSchedules_Staffs_ExecutedById",
                        column: x => x.ExecutedById,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationOutboundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutboundId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PlannedQuantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActualQuantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DispenseStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "TEXT", nullable: false),
                    ResidentConfirmedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RefusalReason = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationOutboundItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationOutboundItems_MedicationOutbounds_OutboundId",
                        column: x => x.OutboundId,
                        principalTable: "MedicationOutbounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationOutboundItems_MedicationSchedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "MedicationSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationOutboundItems_MedicineInventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "MedicineInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationOutboundItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationOutboundItems_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicineDeliveries_InboundId",
                table: "FamilyMedicineDeliveries",
                column: "InboundId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicineDeliveries_OrgId",
                table: "FamilyMedicineDeliveries",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicineDeliveries_ReceivedById",
                table: "FamilyMedicineDeliveries",
                column: "ReceivedById");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicineDeliveries_ResidentId",
                table: "FamilyMedicineDeliveries",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicineDeliveryItems_DeliveryId",
                table: "FamilyMedicineDeliveryItems",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicineDeliveryItems_MedicineId",
                table: "FamilyMedicineDeliveryItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInboundItems_InboundId",
                table: "InventoryInboundItems",
                column: "InboundId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInboundItems_InventoryId",
                table: "InventoryInboundItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInboundItems_MedicineId",
                table: "InventoryInboundItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInbounds_CheckedById",
                table: "InventoryInbounds",
                column: "CheckedById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInbounds_InboundById",
                table: "InventoryInbounds",
                column: "InboundById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInbounds_OrgId",
                table: "InventoryInbounds",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryInbounds_ResidentId",
                table: "InventoryInbounds",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbound_ApprovedById",
                table: "InventoryOutbound",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbound_OrgId",
                table: "InventoryOutbound",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbound_OutboundById",
                table: "InventoryOutbound",
                column: "OutboundById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbound_RequesterId",
                table: "InventoryOutbound",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbound_ResidentId",
                table: "InventoryOutbound",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutboundItem_InventoryId",
                table: "InventoryOutboundItem",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutboundItem_MedicineId",
                table: "InventoryOutboundItem",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutboundItem_OutboundId",
                table: "InventoryOutboundItem",
                column: "OutboundId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStocktakeItems_InventoryId",
                table: "InventoryStocktakeItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStocktakeItems_MedicineId",
                table: "InventoryStocktakeItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStocktakeItems_StocktakeId",
                table: "InventoryStocktakeItems",
                column: "StocktakeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStocktakes_OrgId",
                table: "InventoryStocktakes",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStocktakes_SupervisorId",
                table: "InventoryStocktakes",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutboundItems_InventoryId",
                table: "MedicationOutboundItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutboundItems_MedicineId",
                table: "MedicationOutboundItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutboundItems_OutboundId",
                table: "MedicationOutboundItems",
                column: "OutboundId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutboundItems_ResidentId",
                table: "MedicationOutboundItems",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutboundItems_ScheduleId",
                table: "MedicationOutboundItems",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutbounds_CheckedById",
                table: "MedicationOutbounds",
                column: "CheckedById");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutbounds_OrgId",
                table: "MedicationOutbounds",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOutbounds_PharmacistId",
                table: "MedicationOutbounds",
                column: "PharmacistId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptionItems_MedicineId",
                table: "MedicationPrescriptionItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptionItems_PrescriptionId",
                table: "MedicationPrescriptionItems",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_DoctorId",
                table: "MedicationPrescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_OrgId",
                table: "MedicationPrescriptions",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_ResidentId",
                table: "MedicationPrescriptions",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_ReviewedById",
                table: "MedicationPrescriptions",
                column: "ReviewedById");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationSchedules_ExecutedById",
                table: "MedicationSchedules",
                column: "ExecutedById");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationSchedules_MedicineId",
                table: "MedicationSchedules",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationSchedules_OrgId",
                table: "MedicationSchedules",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationSchedules_OutboundItemId",
                table: "MedicationSchedules",
                column: "OutboundItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationSchedules_PrescriptionItemId",
                table: "MedicationSchedules",
                column: "PrescriptionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationSchedules_ResidentId",
                table: "MedicationSchedules",
                column: "ResidentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMedicineDeliveryItems");

            migrationBuilder.DropTable(
                name: "InventoryInboundItems");

            migrationBuilder.DropTable(
                name: "InventoryStocktakeItems");

            migrationBuilder.DropTable(
                name: "MedicationOutboundItems");

            migrationBuilder.DropTable(
                name: "FamilyMedicineDeliveries");

            migrationBuilder.DropTable(
                name: "InventoryStocktakes");

            migrationBuilder.DropTable(
                name: "MedicationOutbounds");

            migrationBuilder.DropTable(
                name: "MedicationSchedules");

            migrationBuilder.DropTable(
                name: "InventoryInbounds");

            migrationBuilder.DropTable(
                name: "InventoryOutboundItem");

            migrationBuilder.DropTable(
                name: "MedicationPrescriptionItems");

            migrationBuilder.DropTable(
                name: "InventoryOutbound");

            migrationBuilder.DropTable(
                name: "MedicationPrescriptions");
        }
    }
}
