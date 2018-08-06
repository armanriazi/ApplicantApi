using Core.Domain.SeedWork.Repository;
using Core.Domain.SeedWork.Repository.IEntitysRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Core.ProjectInfrastructure.Persistence.RepositoryImplement.EntitiesRepository
{
    public class PriceRepertoryRepository : Repository, IPriceRepertoryRepository
    {
        IConnectionFactory _connectionFactory;

        public PriceRepertoryRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<dynamic>> FindByDapperQueryFinancialYear(string query)
        {
            var storeProcedureName = "[dbo].[ACC_Fy_DdlSelect]";
            var param = new DynamicParameters();
            param.Add("WhereClause1", query);
            param.Add("WhereClause2", null);
            param.Add("WhereClause3", null);
            param.Add("WhereClause4", null);
            param.Add("SortExperssion", null);
            param.Add("TBL_UserID", 1);
            param.Add("ACC_FinancialYearID", null);
            param.Add("TypeOperation", 3);
            param.Add("SQLOut", null);
            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;
        }

        public async Task<IEnumerable<dynamic>> FindByDapperQuerySelectView(string accFinancialYearID,string tblPrcID,string tblPrcIDParent,string tblBprParentId, string sortExpression)
        {
            if (string.IsNullOrEmpty(tblBprParentId))
                tblBprParentId = "0";
            string query= " ACC_FinancialYearID = "+ accFinancialYearID + "  and TBL_PrcID_fk  in (select TBL_PrcID from  TBL_PriceRepertoryCategory where  TBL_PrcID = "+ tblPrcID + " or TBL_PrcParentID_fk = "+tblPrcIDParent+") AND  tbl_bprid != 0 and  tbl_bprparentid_fk  = "+ tblBprParentId ;
            var storeProcedureName = "[dbo].[GLB_SelectView]";
            var param = new DynamicParameters();
            param.Add("WhereClause", query);
            param.Add("ViewName", "V_TBL_BPR");
            param.Add("Fields", "dbo.FXTBL_BprChildCount(TBL_BprID, 1) AS TBL_BprHasChildren,TBL_BprID,TBL_BprParentID_fk,TBL_BprDescription,TBL_BprNote");            
            param.Add("SortExpression", sortExpression);            
            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;
        }

        public async Task<IEnumerable<dynamic>> FindByDapperQueryPriceRepertory(string query)
        {
            var storeProcedureName = "[dbo].[TBL_Prc_DdlSelect]";
            var param = new DynamicParameters();
            param.Add("WhereClause1", "ACC_FinancialYearID="+query);
            param.Add("WhereClause2", null);
            param.Add("WhereClause3", null);
            param.Add("WhereClause4", null);
            param.Add("SortExperssion", null);
            param.Add("TBL_UserID", 1);
            param.Add("ACC_FinancialYearID", null);
            param.Add("TypeOperation", 1);
            param.Add("SQLOut", null);
            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;
        }

        public async Task<IEnumerable<dynamic>> FindByDapperQueryProjectManagementSystemProjectReport(string accFinancialYearID,string bprID, string sortExpression, string  orderBy)
        {
            var storeProcedureName = "[dbo].[PMS_Project_Reports]";
            var param = new DynamicParameters();
            param.Add("PMS_PshID", 0);
            param.Add("WhereClauseOutQuery", "TBL_BprID_fk="+bprID);       
            param.Add("WhereClauseQuery1", null);
            param.Add("WhereClauseQuery2", null);
            param.Add("WhereClauseQuery3", null);
            param.Add("WhereClauseQuery4", null);            
            param.Add("OrderBy", orderBy);            
            param.Add("ACC_FinancialYearID", accFinancialYearID);
            param.Add("TBL_UserID", 1660);
            param.Add("ReportKind", 200);
            param.Add("SQLOut", null);
            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;
        }


        public async Task<IEnumerable<dynamic>> FindByDapperQueryBasePriceRepertoryPriceTextField(string query)
        {            
            var storeProcedureName = "[dbo].[TBL_Bpr_SelectByPk]";
            var param = new DynamicParameters();
            param.Add("TBL_BprID", query);
            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;
        }




        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindAll()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindByConditionalQuery(string id, string where, string sort)
        {
            throw new NotImplementedException();
        }

        Task<dynamic> IReadOnlyRepository.FindById(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindByPredicate(System.Linq.Expressions.Expression<Func<dynamic, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<dynamic>> IReadOnlyRepository.FindByQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}