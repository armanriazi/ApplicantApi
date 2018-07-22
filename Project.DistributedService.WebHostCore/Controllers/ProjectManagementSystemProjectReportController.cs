using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Application.WebHostCore.Services.Internal;

namespace Project.DistributedService.WebHostCore.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> PostProjectManagementSystemProjectReportPlanItemsGridAction([FromBody]ProjectManagementSystemProjectReportGrid projectManagementSystemProjectReport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData =await _projectManagementSystemprojectService.GetProjectManagementSystemReport(projectManagementSystemProjectReport.BudgetProjectId_Fk, projectManagementSystemProjectReport.Orderby,203);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(String))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportPlanDocumentsGridAction([FromBody]String budgetProjectId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(budgetProjectId, "",210);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(String))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportAttachmentsDialogGridAction([FromBody]String documentCode)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReportAttachments(documentCode);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(String))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportPlanContractorsPriceGridAction([FromBody]String budgetprojectid)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(budgetprojectid, "", 225);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }


        public class ProjectManagementSystemProjectReportSendToCartable
        {
            public string BudProjectId { get; set; }
            public string NationalCode { get; set; }
            public string TrackingCode { get; set; }
            public string AccFinancialYearID { get; set; }
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportSendToCartable))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportSendToCartable([FromBody]ProjectManagementSystemProjectReportSendToCartable sendToCartable)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReportSendToCartable(sendToCartable.BudProjectId, sendToCartable.NationalCode, sendToCartable.TrackingCode, sendToCartable.AccFinancialYearID);

            if (resultData == null)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

    }
}

#region comments
//var headers = Request.Headers;            
//var headerValuesStory = headers["melicode"];
//var x = headerValuesStory.FirstOrDefault() != null ? headerValuesStory.FirstOrDefault() : "";
//var resultData = _projectManagementSystemprojectService.GetProjectsById(ProjectManagementSystemprojectreport.BudgetProjectId_Fk, ProjectManagementSystemprojectreport.Orderby);

//if (resultData == null || resultData.Count() == 0)
//{
//    return NotFound();
//}
#endregion