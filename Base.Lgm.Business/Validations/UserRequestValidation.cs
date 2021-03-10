using Base.Lgm.Core.Models.Dto.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
