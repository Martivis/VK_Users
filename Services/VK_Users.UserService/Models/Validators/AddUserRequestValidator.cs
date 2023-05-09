using FluentValidation;
using VK_Users.Common;
using VK_Users.Context.Entities;

namespace VK_Users.UserService.Models.Validators;

public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(p => p.Login).NotEmpty().WithMessage("Login is required");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(p => p.UserGroupId).IsInEnum().WithMessage($"User group should be in {typeof(UserGroupId).GetEnumValuesInString()}");
    }
}
