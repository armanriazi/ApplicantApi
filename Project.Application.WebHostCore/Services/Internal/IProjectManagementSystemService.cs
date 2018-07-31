using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Application.WebHostCore.Services.Internal
{
    public interface IProjectManagementSystemService
    {
        Task<IEnumerable<dynamic>> GetProjectManagementSystemReport(string budgetProjectId_Fk, string orderBy, int reportKind, int? userId, string accFinancialYearID, string desc);
        Task<IEnumerable<dynamic>> GetProjectManagementSystemReportAttachments(string documentCode);
        Task<dynamic> GetProjectManagementSystemReportSendToCartable(string budProjectId, string nationalCode, string trackingCode, string accFinancialYearID);

    }



}
