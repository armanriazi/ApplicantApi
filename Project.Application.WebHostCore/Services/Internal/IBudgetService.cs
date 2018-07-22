using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Application.WebHostCore.Services.Internal
{
    public interface IBudgetService
    {
        Task<IEnumerable<dynamic>> Login(string codeMeli);
    }
}
