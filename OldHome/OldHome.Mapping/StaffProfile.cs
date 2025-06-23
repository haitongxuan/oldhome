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
using OldHome.Core;

namespace OldHome.Mapping
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, StaffSample>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}({src.Position.GetDisplayName()})"));
            CreateMap<Staff, StaffDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<StaffCreateDto, Staff>();
            CreateMap<StaffModifyDto, Staff>().IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
