using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.SeedWork.Repository.IEntitysRepository
{
    public interface IProjectManagementSystemReportRepository : IRepository
    {
        Task<IEnumerable<dynamic>> FindByDapperQuery(string query, string orderBy, int reportKind);
        Task<IEnumerable<dynamic>> FindByDapperQueryDocument(string documentCode);
        Task<dynamic> FindByDapperQuerySendToCartable(string budProjectId, string nationalCode, string trackingCode, string accFinancialYearID);
        


    }

}
