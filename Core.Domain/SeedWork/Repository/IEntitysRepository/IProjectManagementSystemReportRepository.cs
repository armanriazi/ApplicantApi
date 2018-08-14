using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.SeedWork.Repository.IEntitysRepository
{
    public interface IProjectManagementSystemReportRepository : IRepository
    {
        Task<IEnumerable<dynamic>> FindByDapperQuery(string query, string orderBy, int reportKind, int? userId, string accFinancialYearID, string desc);
        Task<IEnumerable<dynamic>> FindByDapperQueryDocument(string documentCode);
        Task<dynamic> FindByDapperQueryDownload(byte fileTypeId, string tblIdID);
        Task<dynamic> FindByDapperQuerySendToCartable(string budProjectId, string nationalCode, string trackingCode, string accFinancialYearID);
        Task<dynamic> FindByDapperQuerySetWinner(string pmsPppId, string budProjectId, string nationoanlCode, string trackingCode, string budPepRegisterDate, string aCCFinancialYearId, string tblUserId);

    }

}
