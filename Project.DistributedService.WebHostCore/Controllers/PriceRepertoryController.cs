using Microsoft.AspNetCore.Mvc;
using Project.Application.WebHostCore.Services.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DistributedService.WebHostCore.Controllers
{
   
    [Route("api/[controller]/[action]")]
    public class PriceRepertoryController : Controller
    {

        private readonly IPriceRepertoryService _PriceRepertoryService;

        public PriceRepertoryController(IPriceRepertoryService PriceRepertoryprojectService)
        {
            _PriceRepertoryService = PriceRepertoryprojectService;
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(String))]
        public async Task<IActionResult> PostPriceRepertoryFinancialYearsSelectListAction([FromBody]String qparam)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _PriceRepertoryService.GetFinancialYears(qparam);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(String))]
        public async Task<IActionResult> PostBasePriceRepertorySelectListAction([FromBody]String qparam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _PriceRepertoryService.GetBasePriceRepertory(qparam);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

        public class PriceRepertorySelectList
        {            
            public string AccFinancialYearID { get; set; }
            public string TblPrcID { get; set; }
            public string TblPrcIDParent { get; set; }
            public string SortExpression { get; set; }
            public string TblBprParentId { get; set; }
            
        }
        [HttpPost]
        [Produces("application/json", Type = typeof(PriceRepertorySelectList))]
        public async Task<IActionResult> PostPriceRepertoryGridAction([FromBody]PriceRepertorySelectList priceRepertorySelectList)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _PriceRepertoryService.GetViewBasePriceRepertory(priceRepertorySelectList.AccFinancialYearID, priceRepertorySelectList.TblPrcID, priceRepertorySelectList.TblPrcIDParent, priceRepertorySelectList.TblBprParentId, priceRepertorySelectList.SortExpression);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }



        public class PriceRepertoryGrid
        {
            public string AccFinancialYearID { get; set; }
            public string TblBprID { get; set; }
            public string SortExpression { get; set; }
            public string OrderBy { get; set; }

        }
        [HttpPost]
        [Produces("application/json", Type = typeof(PriceRepertoryGrid))]
        public async Task<IActionResult> PostProjectManagementSystemProjectReportGridAction([FromBody]PriceRepertoryGrid projectReportSelectList)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _PriceRepertoryService.GetProjectManagementSystemProjectReport(projectReportSelectList.AccFinancialYearID, projectReportSelectList.TblBprID, projectReportSelectList.SortExpression, projectReportSelectList.OrderBy);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(String))]
        public async Task<IActionResult> PostBasePriceRepertoryPriceTextFieldAction([FromBody]String tblBprId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultData = await _PriceRepertoryService.GetBasePriceRepertoryPriceTextField(tblBprId);

            if (resultData == null || resultData.Count() == 0)
            {
                return NotFound();
            }


            return Ok(resultData);
        }

    }
}
