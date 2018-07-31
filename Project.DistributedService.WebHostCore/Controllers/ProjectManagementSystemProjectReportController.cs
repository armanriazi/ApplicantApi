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
            public string BudgetProjectId { get; set; }
            public string Orderby { get; set; }
            public int? UserId { get; set; }
            public string AccFinancialYearId { get; set; }
            public string Desc { get; set; }
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportGrid))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportPlanItemsGridAction([FromBody]ProjectManagementSystemProjectReportGrid projectManagementSystemProjectReport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData =await _projectManagementSystemprojectService.GetProjectManagementSystemReport(projectManagementSystemProjectReport.BudgetProjectId, projectManagementSystemProjectReport.Orderby,203, projectManagementSystemProjectReport.UserId, projectManagementSystemProjectReport.AccFinancialYearId, projectManagementSystemProjectReport.Desc);

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

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(budgetProjectId, "",210,null,"","");

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

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(budgetprojectid, "", 225,null,"","");

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
            public string AccFinancialYearId { get; set; }
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportSendToCartable))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportSendToCartable([FromBody]ProjectManagementSystemProjectReportSendToCartable sendToCartable)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReportSendToCartable(sendToCartable.BudProjectId, sendToCartable.NationalCode, sendToCartable.TrackingCode, sendToCartable.AccFinancialYearId);

            if (resultData == null)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportGrid))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportTechnicalPropertyItemsGridAction([FromBody]ProjectManagementSystemProjectReportGrid projectManagementSystemProjectReport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(projectManagementSystemProjectReport.BudgetProjectId, projectManagementSystemProjectReport.Orderby, 231, projectManagementSystemProjectReport.UserId, projectManagementSystemProjectReport.AccFinancialYearId, projectManagementSystemProjectReport.Desc);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportGrid))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportApprovedBudgetItemsGridAction([FromBody]ProjectManagementSystemProjectReportGrid projectManagementSystemProjectReport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(projectManagementSystemProjectReport.BudgetProjectId, projectManagementSystemProjectReport.Orderby, 204, projectManagementSystemProjectReport.UserId, projectManagementSystemProjectReport.AccFinancialYearId, projectManagementSystemProjectReport.Desc);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportGrid))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportContractItemsGridAction([FromBody]ProjectManagementSystemProjectReportGrid projectManagementSystemProjectReport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(projectManagementSystemProjectReport.BudgetProjectId, projectManagementSystemProjectReport.Orderby, 205, projectManagementSystemProjectReport.UserId, projectManagementSystemProjectReport.AccFinancialYearId, projectManagementSystemProjectReport.Desc);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportGrid))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportOptionsItemsGridAction([FromBody]ProjectManagementSystemProjectReportGrid projectManagementSystemProjectReport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(projectManagementSystemProjectReport.BudgetProjectId, projectManagementSystemProjectReport.Orderby, 203, projectManagementSystemProjectReport.UserId, projectManagementSystemProjectReport.AccFinancialYearId, projectManagementSystemProjectReport.Desc);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(ProjectManagementSystemProjectReportGrid))]
        public async Task<IActionResult> PostProjectManagementSystemProjectAgendaGridAction([FromBody]ProjectManagementSystemProjectReportGrid projectManagementSystemProjectReport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _projectManagementSystemprojectService.GetProjectManagementSystemReport(projectManagementSystemProjectReport.BudgetProjectId, projectManagementSystemProjectReport.Orderby, 206, projectManagementSystemProjectReport.UserId, projectManagementSystemProjectReport.AccFinancialYearId, projectManagementSystemProjectReport.Desc);

            if (resultData == null || resultData.Count() == 0)
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
//var resultData = _projectManagementSystemprojectService.GetProjectsById(ProjectManagementSystemprojectreport.BudgetProjectId, ProjectManagementSystemprojectreport.Orderby);

//if (resultData == null || resultData.Count() == 0)
//{
//    return NotFound();
//}
#endregion