using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Application.WebHostCore.Services.Internal;
using StackExchange.Exceptional;

namespace Project.DistributedService.WebHostCore.Controllers
{
    [Route("api/[controller]")]
    public class BudgetProjectController : Controller
    {


        private readonly IBudgetService _budprojectService;

        public BudgetProjectController(IBudgetService budprojectService)
        {
           _budprojectService = budprojectService;
        }

        public class LoginForm
        {
            public string CodeMeli { get; set; }
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(LoginForm))]
        public async Task<IActionResult> Post([FromBody]LoginForm codeMeli)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData =await _budprojectService.Login(codeMeli.CodeMeli);  
            
            if (resultData == null || resultData.Count()==0)
            {
                return NotFound();
            }
            return Ok(resultData);
        }

    }
}
