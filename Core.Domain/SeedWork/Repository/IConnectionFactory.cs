using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.Domain.SeedWork.Repository
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
        IDbConnection GetConnectionOfDocumentDatabase { get; }
        
    }
}
