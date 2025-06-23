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
    public class MedicationPrescriptionProfile : Profile
    {
        public MedicationPrescriptionProfile()
        {

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
        }
    }
}
