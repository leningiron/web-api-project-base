using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Entities;
using Base.Lgm.Core.Models.Static;
using ExternalBase.Lgm.Utilities.Impl.Base;
using System.Data;

namespace Base.Lgm.Repositories.Impl
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbTransaction transaction) : base(TablesSt.Users, transaction)
        {
        }

    }
}
