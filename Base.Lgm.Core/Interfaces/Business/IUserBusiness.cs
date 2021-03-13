using Base.Lgm.Core.Models.Dto.Request;
using Base.Lgm.Core.Models.Dto.Response;
using ExternalBase.Lgm.Utilities.Dto.Response;
namespace Base.Lgm.Core.Interfaces.Business
{
    public interface IUserBusiness
    {
        GenericReponse<bool> CreateUser(UserRequest request);
    }
}
