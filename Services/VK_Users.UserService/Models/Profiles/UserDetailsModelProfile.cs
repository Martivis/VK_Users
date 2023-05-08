using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.Context.Entities;

namespace VK_Users.UserService.Models.Profiles;

public class UserDetailsModelProfile : Profile
{
    public UserDetailsModelProfile()
    {
        CreateMap<User, UserDetailsModel>()
            .ForMember(t => t.UserState, o => o.MapFrom(s => s.UserState.Code))
            .ForMember(t => t.UserStateDescription, o => o.MapFrom(s => s.UserState.Description))
            .ForMember(t => t.UserGroup, o => o.MapFrom(s => s.UserGroup.Code))
            .ForMember(t => t.UserGroupDescription, o => o.MapFrom(s => s.UserGroup.Description));
    }
}
