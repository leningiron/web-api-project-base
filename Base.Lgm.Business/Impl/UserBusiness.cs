using Base.Lgm.Core.Interfaces.Business;
using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Dto.Request;
using Base.Lgm.Core.Models.Dto.Response;
using Base.Lgm.Core.Models.Entities;
using ExternalBase.Lgm.Utilities.Dto.Response;
using ExternalBase.Lgm.Utilities.Helpers;
using Mapster;
using System.Collections.Generic;

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
                    Error = GenerateErrorHelper.SetError("Error al registrar el usuario.")
                };
            }
            return new GenericReponse<bool> { Data = true };
        }

        public GenericReponse<IList<UserResponse>> GetAllUsers()
        {
            var result = userRepository.GetUsers();

            if (result == null) return new GenericReponse<IList<UserResponse>>();

            return new GenericReponse<IList<UserResponse>>
            {
                Data = result.Adapt<IList<UserResponse>>()
            };
        }

        public GenericReponse<UserResponse> GetUser(int id)
        {
            var result = userRepository.GetUser(x => x.IdUser == id);

            if(result == null) return new GenericReponse<UserResponse>();
            
            return new GenericReponse<UserResponse>
            {
                Data = result.Adapt<UserResponse>()
            };
        }
    }
}
