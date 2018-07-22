using Core.Domain.SeedWork.Repository;
using Core.Domain.SeedWork.Repository.IEntitysRepository;
using System;

namespace Core.ProjectInfrastructure.Persistence.RepositoryImplement
{
    public class UnitOfWorkForProjectManagementSystem : IUnitOfWorkForProjectManagementSystem
    {

        private IProjectManagementSystemReportRepository _projectManagementSystemReportRepository;               
        private bool _disposed;
        public UnitOfWorkForProjectManagementSystem(IProjectManagementSystemReportRepository projectManagementSystemReportRepository)
        {
            _projectManagementSystemReportRepository = projectManagementSystemReportRepository;
        }

        //Accessors for each private repository, creates repository if null  
        public IProjectManagementSystemReportRepository ProjectManagementSystemReportRepository
        {
            get { return _projectManagementSystemReportRepository; }//?? (_projectManagementSystemReportRepository = new ProjectManagementSystemRepository()); }

        }
        public void Commit()
        {
            try
            {
                Console.Write("transaction of UnitOfWorkForProjectManagementSystem Committed");
               // _transaction.Commit();
            }
            catch
            {
                Console.Write("transaction of UnitOfWorkForProjectManagementSystem Rolledback");
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
            _projectManagementSystemReportRepository = null;
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
                    //if (_transaction != null)
                    //{
                    //    _transaction.Dispose();
                    //    _transaction = null;
                    //}
                    //if (_projectManagementSystemReportRepository != null)
                    //{
                    //    _connectionFactory.GetConnection.Dispose();
                    //    _connectionFactory = null;
                    //}
                }
                _disposed = true;
            }
        }

        ~UnitOfWorkForProjectManagementSystem()
        {
            dispose(false);
        }
    }
}
