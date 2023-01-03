using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Application.WebHostCore.Services.Internal;

namespace Project.DistributedService.WebHostCore.Controllers
{
    [Route("api/[controller]")]
    public class ProjectManagementSystemProjectReportController : Controller
    {


        private readonly IProjectManagementSystemService _projectManagementSystemprojectService;

        public ProjectManagementSystemProjectReportController(IProjectManagementSystemService projectManagementSystemprojectService)
        {
            _projectManagementSystemprojectService = projectManagementSystemprojectService;
        }

        public class ProjectManagementSystemProjectReportGrid
        {
            public string BudgetProjectId_Fk { get; set; }
            public string Orderby { get; set; }
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportGrid))]
        public IActionResult PostProjectManagementSystemProjectReportGrid([FromBody]ProjectManagementSystemProjectReportGrid ProjectManagementSystemprojectreport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var headers = Request.Headers;
            ////
            //var headerValuesStory = headers["melicode"];

            //var x = headerValuesStory.FirstOrDefault() != null ? headerValuesStory.FirstOrDefault() : "";

            var resultData =  _projectManagementSystemprojectService.GetProjectsById(ProjectManagementSystemprojectreport.BudgetProjectId_Fk,ProjectManagementSystemprojectreport.Orderby);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }
            return Ok(resultData);
        }

    }
}