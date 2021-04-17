using Base.Lgm.Core.Models.Dto.Request;
using FluentValidation;

namespace Base.Lgm.Business.Validations
{
    public sealed class UserRequestValidation : AbstractValidator<UserRequest>
    {
        public UserRequestValidation()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();           
        }
    }
}
