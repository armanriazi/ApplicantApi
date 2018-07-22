using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.SeedWork.Repository;

namespace Project.Application.WebHostCore.Services.Internal
{

    public class ProjectManagementSystemService : IProjectManagementSystemService
    {
        private readonly IUnitOfWorkForProjectManagementSystem _unitOfWork;
        public ProjectManagementSystemService(IUnitOfWorkForProjectManagementSystem unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    

        public async Task<IEnumerable<dynamic>> GetProjectManagementSystemReport(string budgetProjectId_Fk, string orderBy,int reportKind)
        {
            var result=await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQuery(budgetProjectId_Fk, orderBy, reportKind);           
            return result;
        }

        public async Task<IEnumerable<dynamic>> GetProjectManagementSystemReportAttachments(string documentCode)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQueryDocument(documentCode);
            return result;
        }

        public async Task<dynamic> GetProjectManagementSystemReportSendToCartable(string budProjectId, string nationalCode, string trackingCode, string accFinancialYearID)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQuerySendToCartable(budProjectId, nationalCode, trackingCode, accFinancialYearID);
            return result;
        }
    }
}

