using Base.Lgm.Core.Models.Dto.Request;
using Base.Lgm.Core.Models.Dto.Response;
using ExternalBase.Lgm.Utilities.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Lgm.Core.Interfaces.Business
{
    public interface IUserBusiness
    {
        Task<GenericReponse<bool>> CreateUser(UserRequest request);
        Task<GenericReponse<UserResponse>> GetUser(int id);
        Task<GenericReponse<IList<UserResponse>>> GetAllUsers();
    }
}
