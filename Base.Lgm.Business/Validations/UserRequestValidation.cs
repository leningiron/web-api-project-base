using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Dto.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Lgm.Business.Validations
{
    public sealed class UserRequestValidation : AbstractValidator<UserRequest>
    {
        public UserRequestValidation(IUserRepository userRepository)
        {
            RuleFor(x => x).
                Must((user, context) =>
                {
                    return userRepository.GetUser(x => x.Email == user.Email) == null;
                }).WithMessage($"El correo ya se encuentra registrado en nuestro sistema");

            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();           
        }
    }
}
