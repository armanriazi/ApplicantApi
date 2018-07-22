using Core.Domain.SeedWork.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System;
using Microsoft.Extensions.Configuration;

namespace Core.ProjectInfrastructure.Persistence
{

    public class ConnectionIFactory : IConnectionFactory, IDisposable

    {
        private readonly IConfiguration _conf;
        private DbConnection con;

        public ConnectionIFactory(IConfiguration conf)
        {
            _conf = conf;
        }

        public string GetConnectionString()
        {
            string conret = "";

            foreach (var item in _conf.GetSection("ConnectionStrings").AsEnumerable())
            {
                if (item.Key.Contains("MaliAlborzConnection") && item.Value != string.Empty)
                {
                    conret = item.Value;
                    break;
                }
            }
            return conret;
        }
        public IDbConnection GetConnection
        {
            get
            {
                con = new SqlConnection(GetConnectionString());

                try
                {
                    con.Open();
                }
                catch { }
                return (DbConnection)con;
            }
        }
        //

        public string GetConnectionStringOfDocumentDatabase()
        {
            string conret = "";

            foreach (var item in _conf.GetSection("ConnectionStrings").AsEnumerable())
            {
                if (item.Key.Contains("DocumentDatabaseConnection") && item.Value != string.Empty)
                {
                    conret = item.Value;
                    break;
                }
            }
            return conret;
        }
        public IDbConnection GetConnectionOfDocumentDatabase
        {
            get
            {
                con = new SqlConnection(GetConnectionStringOfDocumentDatabase());

                try
                {
                    con.Open();
                }
                catch { }
                return (DbConnection)con;
            }
        }

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
        // ~ConnectionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    #region comment
    //public static class ConnectionSingelton
    //{
    //    public static IDbConnection CreateConnection(IConfiguration conf)
    //    {
    //        DbProviderFactory dbfactory = null;
    //        var con = dbfactory.CreateConnection();

    //        con.ConnectionString = conf.GetSection("MaliAlborzConnection").Value;
    //        con.Open();

    //        return con;
    //    }
    //}
    #endregion
}
