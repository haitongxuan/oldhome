using AutoMapper;
using OldHome.DTO.Base;
using OldHome.DTO;
using OldHome.Entities.Base;
using OldHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Mapping
{
    public class MedicineInventoryProfile : Profile
    {
        public MedicineInventoryProfile()
        {
            CreateMap<MedicineInventory, MedicineInventoryDto>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident == null ? "" : src.Resident.Name));
            CreateMap<MedicineInventoryCreate, MedicineInventory>();
            CreateMap<MedicineInventoryModify, MedicineInventory>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();

            CreateMap<InventoryInboundItem, MedicineInventory>()
                .ForMember(dest => dest.Medicine, opt => opt.Ignore())
                .ForMember(dest => dest.Resident, opt => opt.Ignore())
                .ForMember(dest => dest.ResidentName, opt => opt.Ignore())
                .ForMember(dest => dest.ResidentCode, opt => opt.Ignore())
                .ForMember(dest => dest.BatchNumber, opt => opt.Ignore())
                .ForMember(dest => dest.ResidentId, opt => opt.MapFrom(src => src.Inbound.ResidentId))
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .ForMember(dest => dest.MedicineBarcode, opt => opt.MapFrom(src => src.Medicine.Barcode))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest => dest.PackageCount, opt => opt.MapFrom(src => src.PackageQuantity))
                .ForMember(dest => dest.QtyRemaining, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.QtyTotal, opt => opt.MapFrom(src => src.Quantity));
            
        }
    }
}
