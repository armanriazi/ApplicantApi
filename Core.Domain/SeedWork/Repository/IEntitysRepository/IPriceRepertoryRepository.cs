using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.SeedWork.Repository.IEntitysRepository
{
   
    public interface IPriceRepertoryRepository : IRepository
    {
        Task<IEnumerable<dynamic>> FindByDapperQueryFinancialYear(string query);
        Task<IEnumerable<dynamic>> FindByDapperQueryPriceRepertory(string query);
        Task<IEnumerable<dynamic>> FindByDapperQuerySelectView(string accFinancialYearID, string tblPrcID, string tblPrcIDParent, string tblBprParentId, string sortExpression);
        Task<IEnumerable<dynamic>> FindByDapperQueryProjectManagementSystemProjectReport(string accFinancialYearID, string bprID, string sortExpression, string orderBy);
        Task<IEnumerable<dynamic>> FindByDapperQueryBasePriceRepertoryPriceTextField(string query);

    }
}
