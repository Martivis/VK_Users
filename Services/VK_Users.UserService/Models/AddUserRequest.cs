using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK_Users.Context.Entities;

namespace VK_Users.UserService;

public class AddUserRequest
{
    public string Login { get; init; }
    public string Password { get; set; }
    public UserGroupCode UserGroupCode { get; init; }
}
