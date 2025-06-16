using Microsoft.EntityFrameworkCore;
using OldHome.Entities;

namespace OldHome.DAL
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<Bed> Beds { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Caregiver> Caregivers { get; set; }
        public DbSet<CaregiverResident> CaregiverResidents { get; set; }
        public DbSet<CaregiverResidentChangeRecord> CaregiverResidentChangeRecords { get; set; }
        public DbSet<CaregiverResidentHistory> CaregiverResidentHistories { get; set; }
        public DbSet<CareRecord> CareRecords { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<MedicationTemplate> MedicationTemplates { get; set; }
        public DbSet<MedicationTemplateItem> MedicationTemplateItems { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineTransactionLog> MedicineTransactionLogs { get; set; }
        public DbSet<MedicineInventory> MedicineInventories { get; set; }
        public DbSet<ResidentMedicineInventory> ResidentMedicineInventories { get; set; }
        public DbSet<Org> Orgs { get; set; }
        public DbSet<OrgArea> OrgAreas { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<ResidentBed> ResidentBeds { get; set; }
        public DbSet<ResidentBedHistory> ResidentBedHistories { get; set; }
        public DbSet<ResidentBedChangeRecord> ResidentBedChangeRecords { get; set; }
        public DbSet<ResidentEmergencyContact> ResidentEmergencyContacts { get; set; }
        public DbSet<ResidentMedication> ResidentMedications { get; set; }
        public DbSet<ResidentMedicationItem> ResidentMedicationItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ResidentSeq> ResidentSeqs { get; set; }
        public DbSet<FamilyMedicineDelivery> FamilyMedicineDeliveries { get; set; }
        public DbSet<FamilyMedicineDeliveryItem> FamilyMedicineDeliveryItems { get; set; }
        public DbSet<InventoryInbound> InventoryInbounds { get; set; }
        public DbSet<InventoryInboundItem> InventoryInboundItems { get; set; }
        public DbSet<InventoryStocktake> InventoryStocktakes { get; set; }
        public DbSet<InventoryStocktakeItem> InventoryStocktakeItems { get; set; }
        public DbSet<MedicationOutbound> MedicationOutbounds { get; set; }
        public DbSet<MedicationOutboundItem> MedicationOutboundItems { get; set; }
        public DbSet<MedicationPrescription> MedicationPrescriptions { get; set; }
        public DbSet<MedicationPrescriptionItem> MedicationPrescriptionItems { get; set; }
        public DbSet<MedicationSchedule> MedicationSchedules { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
    }
}
