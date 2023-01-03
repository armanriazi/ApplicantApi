using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GQ.Schemas.Budgets
{
    public class BudgetProjectService : IBudgetProjectService
    {
        private IList<BudgetProject> _budgetproject;
        public BudgetProjectService()
        {
   
            _budgetproject = new List<BudgetProject>();

            _budgetproject.Add(new BudgetProject(
               bud_projectid: "0324031670",
               projectname:     "پروژه توانیر"          ,
               wos_wonname: "نصب ",
               wos_wotnote: "تجهيزات پست فشارمتوسط هوايي",
               tbl_bprid: "139401303300",
               tbl_bprcode: "3-03300",
               tbl_bprdescription: "حفر چاه نول درزمين دج وپر نمودن آن و حمل  خاک مازاد (مترطول)",
               pms_pdprovidewayid_fk:   2  ,
               pms_pdfirstquantity:9,
               pms_pdmachineryprice: "358000",
               pms_pdpayprice: "219000",
               pms_pdprice: "5193000",
               tbl_bprid_fk: "139401303300",
               pms_pdid: "3337805"
                ));

             _budgetproject.Add(new BudgetProject(
               bud_projectid: "111",
               projectname: "پروژه توانیر",
               wos_wonname: "نصب ",
               wos_wotnote: "شبکه هوايي فشار ضعيف",
               tbl_bprid: "139401500600",
               tbl_bprcode: "5-00600",
               tbl_bprdescription: "پايه بتوني 9/400 چهارگوش (آرماتورنمره 14با وزن تقريبي 102کيلوگرم )",
               pms_pdprovidewayid_fk: 2,
               pms_pdfirstquantity: 1,
               pms_pdmachineryprice: "1715000",
               pms_pdpayprice: "202000",
               pms_pdprice: "5567000",
               tbl_bprid_fk: "139401500600",
               pms_pdid: "3337805"
                ));

            _budgetproject.Add(new BudgetProject(
                bud_projectid: "111",
                projectname: "2پروژه توانیر",
                wos_wonname: "نصب ",
                wos_wotnote: "شبکه هوايي فشار ضعيف",
                tbl_bprid: "139401500600",
                tbl_bprcode: "5990600",
                tbl_bprdescription: "پايه بتوني 9/400 چهارگوش (آرماتورنمره 14با وزن تقريبي 102کيلوگرم )",
                pms_pdprovidewayid_fk: 2,
                pms_pdfirstquantity: 1,
                pms_pdmachineryprice: "1029000",
                pms_pdpayprice: "121200",
                pms_pdprice: "1150200",
                tbl_bprid_fk: "139401500600",
                pms_pdid: "3427389"
                 ));
        }


        public IEnumerable<BudgetProject> Get(string meliCode)
        {
            var result= _budgetproject.Where(o => Equals(o.buD_ProjectID, meliCode)).AsEnumerable();
            return result;
        }

        public Task<IEnumerable<BudgetProject>> GetAsync()
        {            
            return Task.FromResult(_budgetproject.AsEnumerable());
        }
    }
}
