using System;

namespace Base.Lgm.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        public IUserRepository UserdRepository { get; }
    }
}
