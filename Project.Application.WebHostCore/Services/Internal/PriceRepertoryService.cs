using Core.Domain.SeedWork.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.WebHostCore.Services.Internal
{
    public class PriceRepertoryService : IPriceRepertoryService
    {
        private readonly IUnitOfWorkForPriceRepertory _unitOfWork;

        public async Task<IEnumerable<dynamic>> GetFinancialYears(string query)
        {
            var result = await _unitOfWork.PriceRepertoryRepository.FindByDapperQueryFinancialYear(query);
            return result;
        }

        public PriceRepertoryService(IUnitOfWorkForPriceRepertory unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<dynamic>> GetViewBasePriceRepertory(string accFinancialYearID, string tblPrcID, string tblPrcIDParent, string tblBprParentId, string sortExpression)
        {
            var result = await _unitOfWork.PriceRepertoryRepository.FindByDapperQuerySelectView(accFinancialYearID,tblPrcID,tblPrcIDParent, tblBprParentId, sortExpression);
            return result;
        }

        public async Task<IEnumerable<dynamic>> GetBasePriceRepertory(string query)
        {
            var result = await _unitOfWork.PriceRepertoryRepository.FindByDapperQueryPriceRepertory(query);
            return result;
        }
    }
}