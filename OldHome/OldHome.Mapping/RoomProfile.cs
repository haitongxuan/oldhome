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
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomSample>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => $"{src.OrgArea.Name}-{src.RoomNumber}"));
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.OrgAreaName, opt => opt.MapFrom(src => src.OrgArea.Name))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<RoomCreate, Room>();
            CreateMap<RoomModify, Room>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
