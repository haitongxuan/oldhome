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
using OldHome.Core;

namespace OldHome.Mapping
{
    public class MedicationOutboundProfile : Profile
    {
        public MedicationOutboundProfile()
        {

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

            CreateMap<MedicationOutbound, InventoryOutbound>()
                .ForMember(dest => dest.OutboundNumber, opt => opt.MapFrom(src => src.OutboundNumber))
                .ForMember(dest => dest.OutboundDate, opt => opt.MapFrom(src => src.OutboundDate))
                .ForMember(dest => dest.OutboundType, opt => opt.MapFrom(src => src.OutboundType))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => OutboundStatus.Draft));

            CreateMap<MedicationOutboundItem, InventoryOutboundItem>()
                .ForMember(dest => dest.RequestedQuantity, opt => opt.MapFrom(src => src.PlannedQuantity));

        }
    }
}
