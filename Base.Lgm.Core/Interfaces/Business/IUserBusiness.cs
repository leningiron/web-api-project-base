using Base.Lgm.Core.Models.Dto.Request;
using Base.Lgm.Core.Models.Dto.Response;
using ExternalBase.Lgm.Utilities.Dto.Response;
using System.Collections.Generic;

namespace Base.Lgm.Core.Interfaces.Business
{
    public interface IUserBusiness
    {
        GenericReponse<bool> CreateUser(UserRequest request);
        GenericReponse<UserResponse> GetUser(int id);
        GenericReponse<IList<UserResponse>> GetAllUsers();
    }
}
