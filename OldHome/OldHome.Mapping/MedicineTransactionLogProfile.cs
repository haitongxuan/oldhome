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
    public class MedicineTransactionLogProfile : Profile
    {
        public MedicineTransactionLogProfile()
        {
            CreateMap<MedicineTransactionLog, MedicineTransactionLogDto>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .ForMember(dest => dest.ResidentName, opt => opt.MapFrom(src => src.Resident == null ? "" : src.Resident.Name));
            CreateMap<MedicineTransactionLogCreate, MedicineTransactionLog>();
            CreateMap<MedicineTransactionLogModify, MedicineTransactionLog>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
