using System.Linq;
using AutoMapper;
using Abp.Authorization;
using Abp.Authorization.Roles;
using OMTechStation.PropertyPublicity.Authorization.Roles;

namespace OMTechStation.PropertyPublicity.Roles.Dto
{
    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            // Role and permission
            CreateMap<Permission, string>().ConvertUsing(r => r.Name);
            CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

            CreateMap<CreateCountryDto, Role>();

            CreateMap<CountryDto, Role>();

            CreateMap<Role, CountryDto>().ForMember(x => x.GrantedPermissions,
                opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

            CreateMap<Role, RoleListDto>();
            CreateMap<Role, RoleEditDto>();
            CreateMap<Permission, FlatPermissionDto>();
        }
    }
}
