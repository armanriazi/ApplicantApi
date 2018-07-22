using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;

namespace Core.Domain.SeedWork.Repository.IEntitysRepository
{

    public interface IBudgetProjectRepository : IRepository
    {
        Task<IEnumerable<dynamic>> FindByDapperQuery(string query);
    }
}