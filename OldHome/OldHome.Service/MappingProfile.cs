using AutoMapper;
using OldHome.Core;
using OldHome.DTO;
using OldHome.DTO.Base;
using OldHome.Entities;
using OldHome.Entities.Base;

namespace OldHome.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseEntity, BaseDto>().ReverseMap();
            CreateMap<BaseOrgByEntity, BaseOrgByDto>()
                .ForMember(dest => dest.Org, opt => opt.MapFrom(src => src.Org))
                .IncludeBase<BaseEntity, BaseDto>();
            CreateMap<BaseOrgByDto, BaseOrgByEntity>()
                .ForMember(dest => dest.Org, opt => opt.Ignore())
                .ForMember(dest => dest.OrgId, opt => opt.Ignore())
                .IncludeBase<BaseDto, BaseEntity>();

            #region User
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.OrgName, opt => opt.MapFrom(src => src.Org.Name))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(dest => dest.OrgId, opt => opt.MapFrom(src => src.Org.Id))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<UserCreate, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            CreateMap<UserModify, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.Password)))
                 .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region Org
            CreateMap<Org, OrgSample>();
            CreateMap<Org, OrgDto>()
                .ForMember(dest => dest.OrgAreas, opt => opt.MapFrom(src => src.OrgAreas));
            CreateMap<OrgCreate, Org>();
            CreateMap<OrgModify, Org>();
            #endregion

            #region OrgArea
            CreateMap<OrgArea, OrgAreaDto>()
                .ForMember(dest => dest.OrgName, opt => opt.MapFrom(src => src.Org.Name))
                .ForMember(dest => dest.Org, opt => opt.Ignore())
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<OrgAreaCreate, OrgArea>();
            CreateMap<OrgAreaModify, OrgArea>();
            CreateMap<OrgArea, OrgAreaSample>()
                .ForMember(dest => dest.OrgAreaName, opt => opt.MapFrom(src => $"{src.Org.Name}-{src.Name}"));
            #endregion

            #region Role
            CreateMap<Role, RoleSample>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleCreate, Role>();
            CreateMap<RoleModify, Role>();
            #endregion

            #region EmergencyContact
            CreateMap<EmergencyContact, EmergencyContactSample>()
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => $"{src.Name}-{src.PhoneNum}"));
            CreateMap<EmergencyContact, EmergencyContactDto>()
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<EmergencyContactCreate, EmergencyContact>();
            CreateMap<EmergencyContactModify, EmergencyContact>()
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion


            #region Staff
            CreateMap<Staff, StaffSample>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}({src.Position.GetDisplayName()})"));
            CreateMap<Staff, StaffDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<StaffCreateDto, Staff>();
            CreateMap<StaffModifyDto, Staff>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region Department
            CreateMap<Department, DepartmentSample>();
            CreateMap<Department, DepartmentDto>()
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<DepartmentCreate, Department>();
            CreateMap<DepartmentModify, Department>()
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region Room
            CreateMap<Room, RoomSample>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => $"{src.OrgArea.Name}-{src.RoomNumber}"));
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.OrgAreaName, opt => opt.MapFrom(src => src.OrgArea.Name))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<RoomCreate, Room>();
            CreateMap<RoomModify, Room>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region Bed
            CreateMap<Bed, BedSample>()
                .ForMember(dest => dest.BedNum, opt => opt.MapFrom(src => $"{src.Room.RoomNumber}-{src.BedNum}"));
            CreateMap<Bed, BedDto>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.RoomNumber))
                .ForMember(dest => dest.OrgAreaName, opt => opt.MapFrom(src => src.OrgArea.Name))
                .ForMember(dest => dest.Org, opt => opt.Ignore())
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<BedCreate, Bed>();
            CreateMap<BedModify, Bed>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region Medicine
            CreateMap<Medicine, MedicineSample>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name}-({src.Specification})"));
            CreateMap<Medicine, MedicineDto>();
            CreateMap<MedicineCreate, Medicine>();
            CreateMap<MedicineModify, Medicine>();
            #endregion

            #region MedicineInventory
            CreateMap<MedicineInventory, MedicineInventoryDto>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident == null ? "" : src.Resident.Name));
            CreateMap<MedicineInventoryCreate, MedicineInventory>();
            CreateMap<MedicineInventoryModify, MedicineInventory>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region MedicineTransactionLog
            CreateMap<MedicineTransactionLog, MedicineTransactionLogDto>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident == null ? "" : src.Resident.Name));
            CreateMap<MedicineTransactionLogCreate, MedicineTransactionLog>();
            CreateMap<MedicineTransactionLogModify, MedicineTransactionLog>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region MedicationPrescription
            // MedicationPrescriptionItem 映射配置
            CreateMap<MedicationPrescriptionItem, MedicationPrescriptionItemDto>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .IncludeBase<BaseEntity, BaseDto>();

            CreateMap<MedicationPrescriptionItemDto, MedicationPrescriptionItem>()
                .ForMember(dest => dest.Prescription, opt => opt.Ignore()) // 忽略导航属性
                .ForMember(dest => dest.Medicine, opt => opt.Ignore())     // 忽略导航属性
                .IncludeBase<BaseDto, BaseEntity>();

            // MedicationPrescription 映射配置  
            CreateMap<MedicationPrescription, MedicationPrescriptionDto>()
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident.Name))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();

            CreateMap<MedicationPrescriptionDto, MedicationPrescription>()
                .ForMember(dest => dest.Resident, opt => opt.Ignore())    // 忽略导航属性
                ;
            CreateMap<MedicationPrescriptionModifyDto, MedicationPrescription>()
                .ForMember(dest => dest.PrescriptionNumber, opt => opt.Ignore())
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion

            #region MedicationOutbound
            // MedicationOutboundItem 映射配置
            CreateMap<MedicationOutboundItem, MedicationOutboundItemDto>()
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident.Name))
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .IncludeBase<BaseEntity, BaseDto>();

            CreateMap<MedicationOutboundItemDto, MedicationOutboundItem>()
                .ForMember(dest => dest.Outbound, opt => opt.Ignore())
                .ForMember(dest => dest.Resident, opt => opt.Ignore())
                .ForMember(dest => dest.Schedule, opt => opt.Ignore())
                .ForMember(dest => dest.Inventory, opt => opt.Ignore())
                .ForMember(dest => dest.Medicine, opt => opt.Ignore())
                .IncludeBase<BaseDto, BaseEntity>();

            // MedicationOutbound 映射配置
            CreateMap<MedicationOutbound, MedicationOutboundDto>()
                .ForMember(dest => dest.PharmacistName, opt => opt.MapFrom(src => src.Pharmacist.Name))
                .ForMember(dest => dest.CheckedByName, opt => opt.MapFrom(src => src.CheckedBy != null ? src.CheckedBy.Name : ""))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();

            CreateMap<MedicationOutboundDto, MedicationOutbound>()
                .ForMember(dest => dest.Pharmacist, opt => opt.Ignore())
                .ForMember(dest => dest.CheckedBy, opt => opt.Ignore())
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();

            CreateMap<MedicationOutboundCreateDto, MedicationOutbound>()
                .ForMember(dest => dest.Pharmacist, opt => opt.Ignore())
                .ForMember(dest => dest.CheckedBy, opt => opt.Ignore())
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();

            CreateMap<MedicationOutboundModifyDto, MedicationOutbound>()
                .ForMember(dest => dest.Pharmacist, opt => opt.Ignore())
                .ForMember(dest => dest.CheckedBy, opt => opt.Ignore())
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();

            CreateMap<MedicationOutbound, MedicationOutboundSampleDto>()
                .ForMember(dest => dest.PharmacistName, opt => opt.MapFrom(src => src.Pharmacist.Name))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            #endregion

            #region Resident
            CreateMap<Resident, ResidentSample>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(p => p.Room.RoomNumber));
            CreateMap<Resident, ResidentDto>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(p => p.Room.RoomNumber))
                .ForMember(dest => dest.BedNumber, opt => opt.MapFrom(p => p.Bed.BedNum))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(p => DateOnly.FromDateTime(DateTime.Today).Year - p.BirthDate.Year));
            CreateMap<ResidentCreate, Resident>();
            CreateMap<ResidentModify, Resident>()
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            #endregion
        }
    }
}
