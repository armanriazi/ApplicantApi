using Core.Domain.SeedWork.Repository;
using Core.Domain.SeedWork.Repository.IEntitysRepository;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Core.ProjectInfrastructure.Persistence.RepositoryImplement.EntitiesRepository
{
    public class BudgetProjectRepository : Repository,IBudgetProjectRepository
    {
        IConnectionFactory _connectionFactory;

        public BudgetProjectRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<dynamic>> FindByDapperQuery(string query)
        {
            var storeProcedureName = "[dbo].[BUD_Project_DdlSelect]";            
            var param = new DynamicParameters();
            param.Add("WhereClause1", query);
            param.Add("WhereClause2", null);
            param.Add("WhereClause3", null);
            param.Add("WhereClause4", null);
            param.Add("SortExperssion", null);
            param.Add("TBL_UserID", 1);
            param.Add("ACC_FinancialYearID", null);
            param.Add("TypeOperation", 7);
            param.Add("SQLOut", null);
            var list =await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;

            //p.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //int b = p.Get<int>("@b");
        }

        public async Task<IEnumerable<dynamic>> FindByDapperQueryIdentityProjectPlan(string query)
        {
            var storeProcedureName = "[dbo].[BUD_Project_SelectByPK]";
            var param = new DynamicParameters();
            param.Add("BUD_ProjectID", query);           
            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;
        }


        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindAll()
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindByConditionalQuery(string id, string where, string sort)
        {
            throw new System.NotImplementedException();
        }

        Task<dynamic> IReadOnlyRepository.FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindByPredicate(System.Linq.Expressions.Expression<System.Func<dynamic, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindByQuery(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}
