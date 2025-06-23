using AutoMapper;
using OldHome.DTO;
using OldHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Mapping
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {

            CreateMap<Medicine, MedicineSample>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name}-({src.Specification})"));
            CreateMap<Medicine, MedicineDto>();
            CreateMap<MedicineCreate, Medicine>();
            CreateMap<MedicineModify, Medicine>();
        }
    }
}
