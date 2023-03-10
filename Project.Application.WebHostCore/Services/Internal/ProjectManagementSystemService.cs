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
    

        public async Task<IEnumerable<dynamic>> GetProjectManagementSystemReport(string budgetProjectId_Fk, string orderBy,int reportKind, int? userId, string accFinancialYearID, string desc)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQuery(budgetProjectId_Fk, orderBy, reportKind, userId, accFinancialYearID, desc);
            return result;
        }

        public async Task<IEnumerable<dynamic>> GetProjectManagementSystemReportAttachments(string documentCode)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQueryDocument(documentCode);
            return result;
        }
        public async Task<dynamic> GetProjectManagementSystemReportFileDownload(byte fileTypeId, string tblIdID)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQueryDownload(fileTypeId, tblIdID);
            return result;
        }
        public async Task<dynamic> GetProjectManagementSystemReportSendToCartable(string budProjectId, string nationalCode, string trackingCode, string accFinancialYearID)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQuerySendToCartable(budProjectId, nationalCode, trackingCode, accFinancialYearID);
            return result;
        }
        public async Task<dynamic> GetProjectManagementSystemReportSetWinner(string pmsPppId, string budProjectId, string nationoanlCode, string trackingCode, string budPepRegisterDate, string aCCFinancialYearId, string tblUserId)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQuerySetWinner(pmsPppId, budProjectId, nationoanlCode, trackingCode, budPepRegisterDate, aCCFinancialYearId, tblUserId);
            return result;
        }
        public async Task<IEnumerable<dynamic>> GetProjectManagementSystemReportPriceContextTableView(string tBL_PrcID_fk, string orderBy,int reportKind, int? userId, string accFinancialYearID,string desc)
        {
            var result = await _unitOfWork.ProjectManagementSystemReportRepository.FindByDapperQuery(tBL_PrcID_fk, orderBy, reportKind, userId, accFinancialYearID,desc);
            return result;
        }

    }
}

