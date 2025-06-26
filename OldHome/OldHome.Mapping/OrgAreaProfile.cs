using AutoMapper;
using OldHome.DTO;
using OldHome.DTO.Base;
using OldHome.Entities;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Mapping
{
    public class OrgAreaProfile : Profile
    {
        public OrgAreaProfile()
        {
            CreateMap<OrgArea, OrgAreaSample>();
            CreateMap<OrgArea, OrgAreaDto>()
                .ForMember(dest => dest.Org, opt => opt.Ignore())
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<OrgAreaCreate, OrgArea>();
            CreateMap<OrgAreaModify, OrgArea>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
