using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GQ.Schemas.Budgets
{
    public interface IBudgetProjectService
    {
        
        IEnumerable<BudgetProject> Get(string meliCode);
        Task<IEnumerable<BudgetProject>> GetAsync();

    }
}
