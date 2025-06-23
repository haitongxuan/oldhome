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
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleSample>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleCreate, Role>();
            CreateMap<RoleModify, Role>();
        }
    }
}
