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
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentSample>();
            CreateMap<Department, DepartmentDto>()
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<DepartmentCreate, Department>();
            CreateMap<DepartmentModify, Department>()
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
