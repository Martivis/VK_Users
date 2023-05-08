using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.UsersRepository;

namespace VK_Users.UserService.Models.Profiles;

public class AddUserRequestProfile : Profile
{
    public AddUserRequestProfile()
    {
        CreateMap<AddUserRequest, AddUserModel>();
    }
}
