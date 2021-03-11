using Base.Lgm.Core.Models.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Base.Lgm.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Predicate<User> filter);
    }
}
