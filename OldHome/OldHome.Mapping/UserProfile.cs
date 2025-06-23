using AutoMapper;
using OldHome.DTO.Base;
using OldHome.DTO;
using OldHome.Entities.Base;
using OldHome.Entities;

namespace OldHome.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.OrgName, opt => opt.MapFrom(src => src.Org.Name))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(dest => dest.OrgId, opt => opt.MapFrom(src => src.Org.Id))
                .IncludeBase<BaseOrgByEntity, BaseOrgByDto>();
            CreateMap<UserCreate, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
            CreateMap<UserModify, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.Password)))
                 .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .IncludeBase<BaseOrgByDto, BaseOrgByEntity>();
        }
    }
}
