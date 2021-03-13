﻿using Base.Lgm.Core.Interfaces.Business;
using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Dto.Request;
using Base.Lgm.Core.Models.Entities;
using ExternalBase.Lgm.Utilities.Dto;
using ExternalBase.Lgm.Utilities.Dto.Response;
using Mapster;

namespace Base.Lgm.Business.Impl
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public GenericReponse<bool> CreateUser(UserRequest request)
        {
            var destObject = request.Adapt<User>();
            var idResult = userRepository.CreateUser(destObject);
            if (idResult == null)
            {
                return new GenericReponse<bool> 
                {
                    Data = false,
                    Error = new ErrorDto
                    {
                        HttpMessage = "Error al registrar el usuario."
                    }
                };
            }
            return new GenericReponse<bool> { Data = true };
        }
    }
}