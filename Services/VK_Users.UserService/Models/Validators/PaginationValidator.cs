using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_Users.UserService.Models.Validators;

public class PaginationValidator : AbstractValidator<PaginationModel>
{
    public PaginationValidator()
    {
        RuleFor(p => p.Page).GreaterThanOrEqualTo(0).WithMessage("Page can't be negative");
        RuleFor(p => p.PageSize).GreaterThan(0).WithMessage("PageSize should be positive");
    }
}
