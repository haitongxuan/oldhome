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
    public class ResidentProfile : Profile
    {
        public ResidentProfile()
        {

            CreateMap<Resident, ResidentSample>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(p => p.Room.RoomNumber));
            CreateMap<Resident, ResidentDto>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(p => p.Room.RoomNumber))
                .ForMember(dest => dest.BedNumber, opt => opt.MapFrom(p => p.Bed.BedNum))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(p => DateOnly.FromDateTime(DateTime.Today).Year - p.BirthDate.Year));
            CreateMap<ResidentCreate, Resident>();
            CreateMap<ResidentModify, Resident>()
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
