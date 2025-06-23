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
    public class EmergencyContactProfile : Profile
    {
        public EmergencyContactProfile()
        {
            CreateMap<EmergencyContact, EmergencyContactSample>()
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => $"{src.Name}-{src.PhoneNum}"));
            CreateMap<EmergencyContact, EmergencyContactDto>()
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<EmergencyContactCreate, EmergencyContact>();
            CreateMap<EmergencyContactModify, EmergencyContact>()
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
