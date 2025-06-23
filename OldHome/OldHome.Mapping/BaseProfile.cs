using AutoMapper;
using OldHome.DTO.Base;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Mapping
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<BaseEntity, BaseDto>().ReverseMap();
            CreateMap<BaseOrgByEntity, BaseOrgByDto>()
                    .ForMember(dest => dest.Org, opt => opt.MapFrom(src => src.Org))
                    .IncludeBase<BaseEntity, BaseDto>();
            CreateMap<BaseOrgByDto, BaseOrgByEntity>()
                .ForMember(dest => dest.Org, opt => opt.Ignore())
                .ForMember(dest => dest.OrgId, opt => opt.Ignore())
                .IncludeBase<BaseDto, BaseEntity>();
        }
    }
}
