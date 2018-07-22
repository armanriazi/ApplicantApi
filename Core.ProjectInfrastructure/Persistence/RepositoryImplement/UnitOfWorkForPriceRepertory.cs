using Core.Domain.SeedWork.Repository;
using Core.Domain.SeedWork.Repository.IEntitysRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ProjectInfrastructure.Persistence.RepositoryImplement
{
    //PriceRepertory
    public class UnitOfWorkForPriceRepertory : IUnitOfWorkForPriceRepertory
    {
        private IPriceRepertoryRepository _pricerepertoryRepository;
        private bool _disposed;
        public UnitOfWorkForPriceRepertory(IPriceRepertoryRepository pricerepertoryRepository)
        {
            _pricerepertoryRepository = pricerepertoryRepository;
        }

        //Accessors for each private repository, creates repository if null  
        public IPriceRepertoryRepository PriceRepertoryRepository
        {
            get { return _pricerepertoryRepository; }

        }

        public void Commit()
        {
            try
            {
                Console.Write("transaction of UnitOfWorkForPriceRepertory Committed");
                //_transaction.Commit();
            }
            catch
            {
                Console.Write("transaction of UnitOfWorkForPriceRepertory Rolledback");
                //_transaction.Rollback();
                throw;
            }
            finally
            {
                //_transaction.Dispose();
                //_transaction = _connectionFactory.GetConnection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _pricerepertoryRepository = null;
        }

        #region Dispose
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
                    //if (_transaction != null)
                    //{
                    //    _transaction.Dispose();
                    //    _transaction = null;
                    //}
                    //if (_connectionFactory.GetConnection != null)
                    //{
                    //    _connectionFactory.GetConnection.Dispose();
                    //    _connectionFactory = null;
                    //}
                }
                _disposed = true;
            }
        }

        ~UnitOfWorkForPriceRepertory()
        {
            dispose(false);
        }
        #endregion
    }
}