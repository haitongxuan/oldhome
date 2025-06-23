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
    public class OrgProfile : Profile
    {
        public OrgProfile()
        {
            CreateMap<Org, OrgSample>();
            CreateMap<Org, OrgDto>()
                .ForMember(dest => dest.OrgAreas, opt => opt.MapFrom(src => src.OrgAreas));
            CreateMap<OrgCreate, Org>();
            CreateMap<OrgModify, Org>();
        }
    }
}
