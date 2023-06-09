﻿
namespace VK_Users.Context.Entities;

public class UserState
{
    public UserStateId Id { get; set; }
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<User> Users { get; set; } = null!;
}
