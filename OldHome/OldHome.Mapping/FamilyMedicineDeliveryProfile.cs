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
    public class FamilyMedicineDeliveryProfile : Profile
    {
        public FamilyMedicineDeliveryProfile()
        {
            // FamilyMedicineDeliveryItem 映射配置
            CreateMap<FamilyMedicineDeliveryItem, FamilyMedicineDeliveryItemDto>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .IncludeBase<BaseEntity, BaseDto>();

            CreateMap<FamilyMedicineDeliveryItemDto, FamilyMedicineDeliveryItem>()
                .ForMember(dest => dest.Delivery, opt => opt.Ignore())
                .ForMember(dest => dest.Medicine, opt => opt.Ignore())
                .IncludeBase<BaseDto, BaseEntity>();

            // FamilyMedicineDelivery 映射配置
            CreateMap<FamilyMedicineDelivery, DTO.FamilyMedicineDeliveryDto>()
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident.Name))
                .ForMember(dest => dest.ReceivedByName, opt => opt.MapFrom(src => src.ReceivedBy.UserName))
                .ForMember(dest => dest.InboundNumber, opt => opt.MapFrom(src => src.Inbound != null ? src.Inbound.InboundNumber : ""))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();

            CreateMap<DTO.FamilyMedicineDeliveryDto, FamilyMedicineDelivery>()
                .ForMember(dest => dest.Resident, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Inbound, opt => opt.Ignore())
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();

            // 创建和修改映射
            CreateMap<FamilyMedicineDeliveryCreateDto, FamilyMedicineDelivery>()
                .ForMember(dest => dest.Resident, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Inbound, opt => opt.Ignore())
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();

            CreateMap<FamilyMedicineDeliveryModifyDto, FamilyMedicineDelivery>()
                .ForMember(dest => dest.DeliveryNumber, opt => opt.Ignore()) // 送药记录号不允许修改
                .ForMember(dest => dest.Resident, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Inbound, opt => opt.Ignore())
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();

            // 样例映射
            CreateMap<FamilyMedicineDelivery, FamilyMedicineDeliverySampleDto>()
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident.Name))
                .ForMember(dest => dest.DeliveryPersonInfo, opt => opt.MapFrom(src => $"{src.DeliveryPersonName} - {src.DeliveryPersonPhone}"))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();


            CreateMap<FamilyMedicineDeliveryItem, InventoryInboundItem>()
                .ForMember(dest => dest.Medicine, opt => opt.Ignore())
                .ForMember(dest => dest.Inbound, opt => opt.Ignore());
            CreateMap<FamilyMedicineDelivery, InventoryInbound>()
                .ForMember(dest => dest.InboundType, opt => opt.MapFrom(src => InboundType.FamliyProvided))
                .ForMember(dest => dest.SourceType, opt => opt.MapFrom(src => MedicineSourceType.FamilyProvided))
                .ForMember(dest => dest.InboundDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.UtcNow)))
                .ForMember(dest => dest.SourceInfo, opt => opt.MapFrom(src => src.DeliveryNumber));
        }
    }
}