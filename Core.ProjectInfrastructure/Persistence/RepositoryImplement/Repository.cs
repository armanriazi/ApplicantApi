using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.ProjectInfrastructure.Persistence.RepositoryImplement
{
    public abstract class Repository: IDisposable//<T> : IRepository//<T>,IDisposable where T : BaseEntity
    {

        #region read
            public dynamic FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> FindByPredicate(Expression<Func<dynamic, bool>> predicate)
        {
            throw new NotImplementedException();
        }
 
        public IEnumerable<dynamic> FindByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> FindByConditionalQuery(string id, string where, string sort)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> FindAll()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region cud
        public void Add(dynamic entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(dynamic entity)
        {
            throw new NotImplementedException();
        }
   
        public void Update(dynamic entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    
    }
}
  