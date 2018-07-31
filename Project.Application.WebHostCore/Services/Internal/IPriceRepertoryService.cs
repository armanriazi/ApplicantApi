using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.WebHostCore.Services.Internal
{
    public interface IPriceRepertoryService
    {
        Task<IEnumerable<dynamic>> GetFinancialYears(string query);
        Task<IEnumerable<dynamic>> GetBasePriceRepertory(string query);
        Task<IEnumerable<dynamic>> GetViewBasePriceRepertory(string accFinancialYearID, string tblPrcID, string tblPrcIDParent, string tblBprParentId, string sortExpression);
        Task<IEnumerable<dynamic>> GetProjectManagementSystemProjectReport(string accFinancialYearID, string bprID, string sortExpression, string orderBy);
        Task<IEnumerable<dynamic>> GetBasePriceRepertoryPriceTextField(string query);


    }
}
