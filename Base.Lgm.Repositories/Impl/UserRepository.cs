using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Entities;
using System;
using System.Collections.Generic;

namespace Base.Lgm.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        public List<User> DataMock { get; set; } = new List<User>
        {
            new User { IdUser = 1, Email = "pablito@gmail.com"},
            new User { IdUser = 2, Email = "ricardo@gmail.com"},
            new User { IdUser = 3, Email = "cristina@gmail.com"},
            new User { IdUser = 4, Email = "diana@gmail.com"}
        };

        public int? CreateUser(User user)
        {
            this.DataMock.Add(user);
            return null;
        }

        public User GetUser(Predicate<User> filter)
        {
            return this.DataMock.Find(filter);
        }
    }
}
