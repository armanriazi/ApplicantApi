using Core.Domain.SeedWork.Repository;
using Core.Domain.SeedWork.Repository.IEntitysRepository;
using System;

namespace Core.ProjectInfrastructure.Persistence.RepositoryImplement
{
    public class UnitOfWorkForBudget : IUnitOfWorkForBudget
    {
        private IBudgetProjectRepository _budprojectRepository;
        private bool _disposed;                
        public UnitOfWorkForBudget(IBudgetProjectRepository budprojectRepository)
        {
            _budprojectRepository = budprojectRepository;
        }

        //Accessors for each private repository, creates repository if null  
        public IBudgetProjectRepository BudgetProjectRepository
        {
            get { return _budprojectRepository; }// ?? (_budprojectRepository = new BudgetProjectRepository()); }
 
        }

        public void Commit()
        {
            try
            {
                Console.Write("transaction of UnitOfWorkForBudget Committed");
                //_transaction.Commit();
            }
            catch
            {
                Console.Write("transaction of UnitOfWorkForBudget Rolledback");
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
            _budprojectRepository = null;            
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

        ~UnitOfWorkForBudget()
        {
            dispose(false);
        }
        #endregion
    }
}
