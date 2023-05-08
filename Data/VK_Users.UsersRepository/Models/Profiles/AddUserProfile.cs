using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.Context.Entities;

namespace VK_Users.UsersRepository.Models.Profiles;

internal class AddUserProfile : Profile
{
    public AddUserProfile()
    {
        CreateMap<AddUserModel, User>();
    }
}
