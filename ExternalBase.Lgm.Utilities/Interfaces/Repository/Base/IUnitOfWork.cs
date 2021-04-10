using System;
namespace ExternalBase.Lgm.Utilities.Interfaces.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
