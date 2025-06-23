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
    public class BedProfile : Profile
    {
        public BedProfile()
        {

            CreateMap<Bed, BedSample>()
                .ForMember(dest => dest.BedNum, opt => opt.MapFrom(src => $"{src.Room.RoomNumber}-{src.BedNum}"));
            CreateMap<Bed, BedDto>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.RoomNumber))
                .ForMember(dest => dest.OrgAreaName, opt => opt.MapFrom(src => src.OrgArea.Name))
                .ForMember(dest => dest.Org, opt => opt.Ignore())
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<BedCreate, Bed>();
            CreateMap<BedModify, Bed>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
