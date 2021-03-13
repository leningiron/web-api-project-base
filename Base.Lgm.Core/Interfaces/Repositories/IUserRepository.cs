using Base.Lgm.Core.Models.Entities;
using System;

namespace Base.Lgm.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Predicate<User> filter);
        int? CreateUser(User user);
    }
}
