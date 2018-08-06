using Core.Domain.SeedWork.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Application.WebHostCore.Services.Internal
{
    public class BudgetService : IBudgetService
    {
        private readonly IUnitOfWorkForBudget _unitOfWork;
        public BudgetService(IUnitOfWorkForBudget unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<dynamic>> Login(string codeMeli)
        {
            var result=await _unitOfWork.BudgetProjectRepository.FindByDapperQuery(codeMeli);    
            return result;
        }
        public async Task<IEnumerable<dynamic>> GetBudgetProjectPlanTextFields(string query)
        {
            var result = await _unitOfWork.BudgetProjectRepository.FindByDapperQueryIdentityProjectPlan(query);
            return result;
        }
    }
}
