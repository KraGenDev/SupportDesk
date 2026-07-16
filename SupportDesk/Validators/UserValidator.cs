using FluentValidation;
using SupportDesk.Core.Domain.Models;

namespace SupportDesk.Api.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        { 
            RuleFor(x => x.Name).NotEmpty().Length(2,100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Length(6,25);
        }
    }
}
