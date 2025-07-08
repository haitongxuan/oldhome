using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldHome.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Specification = table.Column<string>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    StorageMethod = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    PackageUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    MinUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    QtyPerPackage = table.Column<int>(type: "INTEGER", nullable: false),
                    Barcode = table.Column<string>(type: "TEXT", nullable: false),
                    ApprovalNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNum = table.Column<string>(type: "TEXT", nullable: false),
                    IsHead = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StaffCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNum = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    FloorMax = table.Column<int>(type: "INTEGER", nullable: false),
                    FloorMin = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgAreas_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentSeqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Seq = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentSeqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentSeqs_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerialNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentValue = table.Column<int>(type: "INTEGER", nullable: false),
                    Prefix = table.Column<string>(type: "TEXT", nullable: false),
                    Suffix = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialNumbers_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNum = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    LeaveDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffs_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RoomType = table.Column<int>(type: "INTEGER", nullable: false),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    OrgAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    BedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FreeBedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFull = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_OrgAreas_OrgAreaId",
                        column: x => x.OrgAreaId,
                        principalTable: "OrgAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryOutbounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutboundNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OutboundType = table.Column<int>(type: "INTEGER", nullable: false),
                    OutboundDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    RequesterId = table.Column<int>(type: "INTEGER", nullable: true),
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
                    table.PrimaryKey("PK_InventoryOutbounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOutbounds_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOutbounds_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOutbounds_Users_OutboundById",
                        column: x => x.OutboundById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOutbounds_Users_RequesterId",
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
                name: "Caregivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false),
                    CareLevelCapability = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFullTime = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxResidentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
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
                    table.PrimaryKey("PK_Caregivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caregivers_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caregivers_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsFromPublicInventory = table.Column<bool>(type: "INTEGER", nullable: false),
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
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BedNum = table.Column<string>(type: "TEXT", nullable: false),
                    OrgAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusNotes = table.Column<string>(type: "TEXT", nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_OrgAreas_OrgAreaId",
                        column: x => x.OrgAreaId,
                        principalTable: "OrgAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beds_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    IdCardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    AdmissionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    OrgAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    BedId = table.Column<int>(type: "INTEGER", nullable: false),
                    HealthStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    HealthDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residents_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Residents_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Residents_OrgAreas_OrgAreaId",
                        column: x => x.OrgAreaId,
                        principalTable: "OrgAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Residents_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Residents_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BillNum = table.Column<string>(type: "TEXT", nullable: false),
                    BillDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Paid = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaregiverResidentChangeRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromCaregiverId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToCaregiverId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeType = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaregiverResidentChangeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentChangeRecords_Caregivers_FromCaregiverId",
                        column: x => x.FromCaregiverId,
                        principalTable: "Caregivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentChangeRecords_Caregivers_ToCaregiverId",
                        column: x => x.ToCaregiverId,
                        principalTable: "Caregivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentChangeRecords_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentChangeRecords_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaregiverResidentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaregiverId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaregiverResidentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentHistories_Caregivers_CaregiverId",
                        column: x => x.CaregiverId,
                        principalTable: "Caregivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentHistories_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaregiverResidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaregiverId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaregiverResidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaregiverResidents_Caregivers_CaregiverId",
                        column: x => x.CaregiverId,
                        principalTable: "Caregivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaregiverResidents_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CareRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareRecords_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareRecords_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContactResident",
                columns: table => new
                {
                    EmergencyContactsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContactResident", x => new { x.EmergencyContactsId, x.ResidentsId });
                    table.ForeignKey(
                        name: "FK_EmergencyContactResident_EmergencyContacts_EmergencyContactsId",
                        column: x => x.EmergencyContactsId,
                        principalTable: "EmergencyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyContactResident_Residents_ResidentsId",
                        column: x => x.ResidentsId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    SourceInfo = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "MedicationOutboundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutboundId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlannedQuantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActualQuantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    DispenseStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentConfirmedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "MedicationPrescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriptionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    PrescriptionType = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Diagnosis = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "MedicineInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MedicineName = table.Column<string>(type: "TEXT", nullable: false),
                    MedicineBarcode = table.Column<string>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PackageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    QtyRemaining = table.Column<decimal>(type: "TEXT", nullable: false),
                    QtyTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ResidentName = table.Column<string>(type: "TEXT", nullable: true),
                    ResidentCode = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_MedicineInventories_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineInventories_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
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
                name: "ResidentBedHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    BedId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckInDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorName = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentBedHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentBedHistories_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentBedHistories_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentBedHistories_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentBedHistories_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentBeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    BedId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckInDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_ResidentBeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentBeds_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentBeds_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentBeds_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentBeds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentEmergencyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmergencyContactId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Relationship = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentEmergencyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentEmergencyContacts_EmergencyContacts_EmergencyContactId",
                        column: x => x.EmergencyContactId,
                        principalTable: "EmergencyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentEmergencyContacts_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentMedications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
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
                    table.PrimaryKey("PK_ResidentMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentMedications_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentMedications_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentMedications_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
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
                name: "MedicationPrescriptionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Dosage = table.Column<string>(type: "TEXT", nullable: false),
                    DosageAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    MedicationType = table.Column<int>(type: "INTEGER", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "TEXT", nullable: false),
                    IsPRN = table.Column<bool>(type: "INTEGER", nullable: false),
                    PRNCondition = table.Column<string>(type: "TEXT", nullable: true),
                    MaxDailyDose = table.Column<decimal>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "InventoryInboundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InboundId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "InventoryOutboundItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutboundId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: true),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RequestedQuantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActualQuantity = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_InventoryOutboundItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOutboundItems_InventoryOutbounds_OutboundId",
                        column: x => x.OutboundId,
                        principalTable: "InventoryOutbounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOutboundItems_MedicineInventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "MedicineInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOutboundItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOutboundItems_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
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
                    InventoryType = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        name: "FK_MedicineTransactionLogs_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineTransactionLogs_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResidentMedicationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResidentMedicationId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineTime = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicineType = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectiveDateFrom = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EffectiveDateTo = table.Column<DateOnly>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_ResidentMedicationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentMedicationItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentMedicationItems_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentMedicationItems_ResidentMedications_ResidentMedicationId",
                        column: x => x.ResidentMedicationId,
                        principalTable: "ResidentMedications",
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
                    Unit = table.Column<int>(type: "INTEGER", nullable: false),
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
                        name: "FK_MedicationSchedules_InventoryOutboundItems_OutboundItemId",
                        column: x => x.OutboundItemId,
                        principalTable: "InventoryOutboundItems",
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

            migrationBuilder.CreateIndex(
                name: "IX_Beds_OrgAreaId",
                table: "Beds",
                column: "OrgAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_OrgId",
                table: "Beds",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_OrgId",
                table: "Bills",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ResidentId",
                table: "Bills",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentChangeRecords_CreatorId",
                table: "CaregiverResidentChangeRecords",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentChangeRecords_FromCaregiverId",
                table: "CaregiverResidentChangeRecords",
                column: "FromCaregiverId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentChangeRecords_ResidentId",
                table: "CaregiverResidentChangeRecords",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentChangeRecords_ToCaregiverId",
                table: "CaregiverResidentChangeRecords",
                column: "ToCaregiverId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentHistories_CaregiverId",
                table: "CaregiverResidentHistories",
                column: "CaregiverId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentHistories_ResidentId",
                table: "CaregiverResidentHistories",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidents_CaregiverId",
                table: "CaregiverResidents",
                column: "CaregiverId");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidents_ResidentId",
                table: "CaregiverResidents",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Caregivers_OrgId",
                table: "Caregivers",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Caregivers_StaffId",
                table: "Caregivers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CareRecords_ResidentId",
                table: "CareRecords",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_CareRecords_StaffId",
                table: "CareRecords",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrgId",
                table: "Departments",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContactResident_ResidentsId",
                table: "EmergencyContactResident",
                column: "ResidentsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_OrgId",
                table: "EmergencyContacts",
                column: "OrgId");

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
                name: "IX_InventoryOutboundItems_InventoryId",
                table: "InventoryOutboundItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutboundItems_MedicineId",
                table: "InventoryOutboundItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutboundItems_OutboundId",
                table: "InventoryOutboundItems",
                column: "OutboundId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutboundItems_ResidentId",
                table: "InventoryOutboundItems",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbounds_ApprovedById",
                table: "InventoryOutbounds",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbounds_OrgId",
                table: "InventoryOutbounds",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbounds_OutboundById",
                table: "InventoryOutbounds",
                column: "OutboundById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOutbounds_RequesterId",
                table: "InventoryOutbounds",
                column: "RequesterId");

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
                name: "IX_MedicationPrescriptions_OrgId",
                table: "MedicationPrescriptions",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPrescriptions_ResidentId",
                table: "MedicationPrescriptions",
                column: "ResidentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInventories_MedicineId",
                table: "MedicineInventories",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInventories_OrgId",
                table: "MedicineInventories",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInventories_ResidentId",
                table: "MedicineInventories",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_MedicineId",
                table: "MedicineTransactionLogs",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_MedicineInventoryId",
                table: "MedicineTransactionLogs",
                column: "MedicineInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_OrgId",
                table: "MedicineTransactionLogs",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransactionLogs_ResidentId",
                table: "MedicineTransactionLogs",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgAreas_OrgId",
                table: "OrgAreas",
                column: "OrgId");

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
                name: "IX_ResidentBedHistories_BedId",
                table: "ResidentBedHistories",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedHistories_OperatorId",
                table: "ResidentBedHistories",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedHistories_ResidentId",
                table: "ResidentBedHistories",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBedHistories_RoomId",
                table: "ResidentBedHistories",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBeds_BedId",
                table: "ResidentBeds",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBeds_OrgId",
                table: "ResidentBeds",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBeds_ResidentId",
                table: "ResidentBeds",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentBeds_RoomId",
                table: "ResidentBeds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentEmergencyContacts_EmergencyContactId",
                table: "ResidentEmergencyContacts",
                column: "EmergencyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentEmergencyContacts_ResidentId",
                table: "ResidentEmergencyContacts",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedicationItems_MedicineId",
                table: "ResidentMedicationItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedicationItems_OrgId",
                table: "ResidentMedicationItems",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedicationItems_ResidentMedicationId",
                table: "ResidentMedicationItems",
                column: "ResidentMedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedications_OrgId",
                table: "ResidentMedications",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedications_ResidentId",
                table: "ResidentMedications",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMedications_RoomId",
                table: "ResidentMedications",
                column: "RoomId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Residents_BedId",
                table: "Residents",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_DepartmentId",
                table: "Residents",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_OrgAreaId",
                table: "Residents",
                column: "OrgAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_OrgId",
                table: "Residents",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_RoomId",
                table: "Residents",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentSeqs_OrgId",
                table: "ResidentSeqs",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OrgAreaId",
                table: "Rooms",
                column: "OrgAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OrgId",
                table: "Rooms",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_OrgId",
                table: "SerialNumbers",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                table: "Staffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_OrgId",
                table: "Staffs",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrgId",
                table: "Users",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CaregiverResidentChangeRecords");

            migrationBuilder.DropTable(
                name: "CaregiverResidentHistories");

            migrationBuilder.DropTable(
                name: "CaregiverResidents");

            migrationBuilder.DropTable(
                name: "CareRecords");

            migrationBuilder.DropTable(
                name: "EmergencyContactResident");

            migrationBuilder.DropTable(
                name: "FamilyMedicineDeliveryItems");

            migrationBuilder.DropTable(
                name: "InventoryInboundItems");

            migrationBuilder.DropTable(
                name: "InventoryStocktakeItems");

            migrationBuilder.DropTable(
                name: "MedicationOutboundItems");

            migrationBuilder.DropTable(
                name: "MedicationSchedules");

            migrationBuilder.DropTable(
                name: "MedicineTransactionLogs");

            migrationBuilder.DropTable(
                name: "ResidentBedChangeRecords");

            migrationBuilder.DropTable(
                name: "ResidentBedHistories");

            migrationBuilder.DropTable(
                name: "ResidentBeds");

            migrationBuilder.DropTable(
                name: "ResidentEmergencyContacts");

            migrationBuilder.DropTable(
                name: "ResidentMedicationItems");

            migrationBuilder.DropTable(
                name: "ResidentMedicineInventories");

            migrationBuilder.DropTable(
                name: "ResidentSeqs");

            migrationBuilder.DropTable(
                name: "SerialNumbers");

            migrationBuilder.DropTable(
                name: "Caregivers");

            migrationBuilder.DropTable(
                name: "FamilyMedicineDeliveries");

            migrationBuilder.DropTable(
                name: "InventoryStocktakes");

            migrationBuilder.DropTable(
                name: "MedicationOutbounds");

            migrationBuilder.DropTable(
                name: "InventoryOutboundItems");

            migrationBuilder.DropTable(
                name: "MedicationPrescriptionItems");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "ResidentMedications");

            migrationBuilder.DropTable(
                name: "InventoryInbounds");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "InventoryOutbounds");

            migrationBuilder.DropTable(
                name: "MedicineInventories");

            migrationBuilder.DropTable(
                name: "MedicationPrescriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "OrgAreas");

            migrationBuilder.DropTable(
                name: "Orgs");
        }
    }
}
