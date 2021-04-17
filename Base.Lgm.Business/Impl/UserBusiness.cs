using Base.Lgm.Core.Interfaces.Business;
using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Dto.Request;
using Base.Lgm.Core.Models.Dto.Response;
using Base.Lgm.Core.Models.Entities;
using ExternalBase.Lgm.Utilities.Dto.Response;
using ExternalBase.Lgm.Utilities.Helpers;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Lgm.Business.Impl
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork unitOfWork;

        public UserBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<GenericReponse<bool>> CreateUser(UserRequest request)
        {
            var destObject = request.Adapt<User>();
            var idResult = await unitOfWork.UserdRepository.AddAsync(destObject);
            if (idResult>0)
            {
                return new GenericReponse<bool>
                {
                    Data = false,
                    Error = GenerateErrorHelper.SetError("Error al registrar el usuario.")
                };
            }
            return new GenericReponse<bool> { Data = true };
        }

        public async Task<GenericReponse<IList<UserResponse>>> GetAllUsers()
        {
            var result = await unitOfWork.UserdRepository.GetAllAsync();

            if (result == null) return new GenericReponse<IList<UserResponse>>();

            return new GenericReponse<IList<UserResponse>>
            {
                Data = result.Adapt<IList<UserResponse>>()
            };
        }

        public async Task<GenericReponse<UserResponse>> GetUser(int id)
        {
            var result = await unitOfWork.UserdRepository.GetAsync(id);

            if(result == null) return new GenericReponse<UserResponse>();
            
            return new GenericReponse<UserResponse>
            {
                Data = result.Adapt<UserResponse>()
            };
        }
    }
}
