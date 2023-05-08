using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.Context.Entities;

namespace VK_Users.UsersRepository.Models.Profiles;

public class UserModelProfile : Profile
{
    public UserModelProfile()
    {
        CreateMap<User, UserModel>()
            .ReverseMap();
    }
}
