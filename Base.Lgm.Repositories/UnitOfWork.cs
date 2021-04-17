using Base.Lgm.Core.Interfaces.Repositories;
using Base.Lgm.Core.Models.Static;
using Base.Lgm.Repositories.Impl;
using ExternalBase.Lgm.Utilities.Interfaces.Repositories.Base;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Base.Lgm.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection Connection;
        private IDbTransaction Transaction;

        private IUserRepository userRepository;

        private bool _disposed;

        public UnitOfWork()
        {
            Connection = new SqlConnection(SettingDataBaseSt.ConnectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        #region  respos

        #endregion
        public IUserRepository UserdRepository
        {
            get { return userRepository ?? (userRepository = new UserRepository(Transaction)); }
        }


        private void resetRepositories()
        {
            userRepository = null;          
        }

        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
            finally
            {
                Transaction.Dispose();
                Transaction = Connection.BeginTransaction();
                resetRepositories();
            }
        }



        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                    if (Connection != null)
                    {
                        Connection.Dispose();
                        Connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
