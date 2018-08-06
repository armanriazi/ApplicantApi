using Core.Domain.SeedWork.Repository;
using Core.Domain.SeedWork.Repository.IEntitysRepository;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Core.ProjectInfrastructure.Persistence.RepositoryImplement.EntitiesRepository
{
    public class ProjectManagementSystemRepository : Repository , IProjectManagementSystemReportRepository
    {
        IConnectionFactory _connectionFactory;

        public ProjectManagementSystemRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<dynamic>> FindByDapperQuery(string query, string orderBy,int reportKind,int? userId,string accFinancialYearID,string desc)
        {
            var storeProcedureName = "[dbo].[PMS_Project_Reports]";
            var param = new DynamicParameters();
            string whereClauseOutQuery = "";

            string _whereClauseQuery2 = "";
            string _whereClauseQuery4 = "";      

            switch (reportKind)
            {
                case 201:
                    whereClauseOutQuery = "TBL_PrcID_fk="+query+" AND ACC_FinancialYearID=" + accFinancialYearID;
                    break;
                case 202:
                    whereClauseOutQuery = "BUD_ProjectID_fk=" + query ;                   
                    break;
                case 203:
                    if (desc == "plansupervisionhistory")
                        whereClauseOutQuery = "BUD_ProjectID_fk=" + query + " and TBL_BpriD_fk<>0 and WHS_WarehouseID_fk=0 and COM_ServiceID_fk=0 and TBl_BpriD_fk<>0";
                    else
                    {
                        whereClauseOutQuery = "BUD_ProjectID_fk=" + query + " and  WHS_WarehouseID_fk=0 and COM_ServiceID_fk=0 and TBl_BpriD_fk<>0";
                        _whereClauseQuery4 = "1";
                    }
                    break;
                case 204:
                    whereClauseOutQuery = query;                    
                    break;
                case 205:
                    whereClauseOutQuery = "CNT_Contractid_fk<>0  and BUD_ProjectID_fk="+ query;
                    break;
                case 206:
                    whereClauseOutQuery = "WOS_WoID_fk<>0  and  BUD_ProjectID_fk=" + query;
                    break;
                case 207:
                    whereClauseOutQuery = "BUD_ProjectID_fk=" + query;
                    break;
                case 208:
                    whereClauseOutQuery = "BUD_ProjectID_fk=" + query;
                    break;
                case 209:
                    whereClauseOutQuery = "BUD_ProjectID_fk=" + query;
                    break;
                case 210:
                    whereClauseOutQuery = "BUD_ProjectID_fk=" + query + " and PMS_PdtparentID_fk in(100,200)";
                    _whereClauseQuery4 = "1";
                    break;
                case 225:
                    whereClauseOutQuery = query;
                    break;
                case 231:
                    whereClauseOutQuery = query;
                    _whereClauseQuery2 = query;
                    break;                
            }
            param.Add("PMS_PshID", 0);
            param.Add("WhereClauseOutQuery", whereClauseOutQuery);
            param.Add("WhereClauseQuery1", null);            
            param.Add("WhereClauseQuery2", _whereClauseQuery2);
            param.Add("WhereClauseQuery3", null);
            param.Add("WhereClauseQuery4", _whereClauseQuery4);            
            param.Add("OrderBy", orderBy);            
            param.Add("ACC_FinancialYearID", accFinancialYearID);
            param.Add("TBL_UserID", userId);
            param.Add("ReportKind", reportKind);
            param.Add("SqlOut", null);

            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;            
        }

        public async Task<IEnumerable<dynamic>> FindByDapperQueryDocument(string documentCode)
        {
            var storeProcedureName = "[dbo].[GLB_SelectDocument]";
            var param = new DynamicParameters();

            param.Add("@DocumentCode", documentCode);
            param.Add("@TBL_UserID", null);
            param.Add("@TypeOperation", 1);

            var list = await SqlMapper.QueryAsync(_connectionFactory.GetConnectionOfDocumentDatabase, storeProcedureName, param, commandType: CommandType.StoredProcedure);
            return list;
        }

        public async Task<dynamic> FindByDapperQuerySendToCartable(string budProjectId, string nationalCode, string trackingCode, string accFinancialYearID)
        {
          
            var storeProcedureName = "select dbo.FxBUD_ProjectValidationForAddEditDelete(" + budProjectId + "," + accFinancialYearID + ",1,17" + ")";
            var output = SqlMapper.QueryFirst<string>(_connectionFactory.GetConnection, storeProcedureName);
            if (output != "")
                return output;

            storeProcedureName = "[dbo].[PMS_Ppp_SendToCartable]";
            var param = new DynamicParameters();

            param.Add("@BUD_ProjectID_fk", budProjectId);
            param.Add("@NationoanlCode", nationalCode);
            param.Add("@Trackingcode", trackingCode);
            param.Add("@BUD_PepRegisterDate", DateTime.Now.ToShortDateString());
            param.Add("@ACC_FinancialYearID", accFinancialYearID);
            param.Add("@TBL_UserID", 1);


            // در کل این بلاک مهم نیست و داخل برنامه کلاینت ساید در قسمت گرید قیمت پیمانکاران به طرح بر اساس تعداد سطرهای افزوده شده چک می شود
            try {
                var list =await  SqlMapper.QueryFirstAsync(_connectionFactory.GetConnection, storeProcedureName, param, commandType: CommandType.StoredProcedure);
                return list.OutputMessage;
            }
            catch(Exception e)
            {
                if (e.Message == "Sequence contains no elements")
                {
                    return "با موفقیت منتقل گردید";
                }
            }
            return "عملیات ناموفق بود لطفا با پشتیبانی تماس حاصل فرمائید";
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
