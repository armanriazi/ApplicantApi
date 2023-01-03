using System;
using System.Collections.Generic;
using System.Text;

namespace GQ.Schemas.Budgets
{
    public class BudgetProject
    {
        //public BudgetProject(string name, string description, DateTime created, int customerId, string id = null)
        //{
        //    if (id == null)
        //        id = Guid.NewGuid().ToString();

        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Created = created;
        //    CustomerId = customerId;
        //    Status = BudgetStatuses.CREATED;
        //}

        public BudgetProject(
            string bud_projectid     ,       
            string projectname       ,          
            string wos_wonname       ,
            string wos_wotnote       ,
            string tbl_bprid         ,
            string tbl_bprcode       ,
            string tbl_bprdescription,
            int pms_pdprovidewayid_fk,
            int pms_pdfirstquantity,
            string pms_pdmachineryprice ,
            string pms_pdpayprice    ,
            string pms_pdprice       ,
            string tbl_bprid_fk      ,
            string pms_pdid         )        
 {

            buD_ProjectID                 =  bud_projectid           ;
            projectName                   =  projectname             ;
            woS_WonName                   =  wos_wonname             ;
            woS_WotNote                   =  wos_wotnote             ;
            tbL_BprID                     =  tbl_bprid               ;
            tbL_BprCode                   =  tbl_bprcode             ;
            tbL_BprDescription            =  tbl_bprdescription      ;
            pmS_PdProvideWayId_fk         =  pms_pdprovidewayid_fk    ;
            pmS_PdFirstQuantity = pms_pdfirstquantity;
            pmS_PdMachineryPrice          =  pms_pdmachineryprice     ;
            pmS_PdPayPrice                =  pms_pdpayprice          ;
            pmS_PdPrice                   =  pms_pdprice             ;
            tbL_BprID_fk                  =  tbl_bprid_fk            ;
            pmS_PdID                      =  pms_pdid;
}


        public string buD_ProjectID     { get;  set; }

        public string projectName       { get; set; }

        public string woS_WonName       { get; set; }
        public string woS_WotNote        { get; set; }
        public string tbL_BprID             { get; set; }
        public string tbL_BprCode           { get; set; }
        public string tbL_BprDescription    { get; set; }
        public int pmS_PdProvideWayId_fk     { get; private set; }
        public int pmS_PdFirstQuantity { get;  set; }        
        public string pmS_PdMachineryPrice     { get;  set; }
        public string pmS_PdPayPrice     { get; set; }
        public string pmS_PdPrice        { get; set; }
        public string tbL_BprID_fk       { get;private set; }
        public string pmS_PdID               { get; private set; }
        //public DateTime Created { get; private set; }

        //public BudgetStatuses Status { get; private set; }

        //public void Close()
        //{
        //    Status = BudgetStatuses.CLOSED;
        //}

        //public void Start()
        //{
        //    Status = BudgetStatuses.PROCESSING;
        //}

        //public void Cancel()
        //{
        //    Status = BudgetStatuses.CANCELLED;
        //}

        //public void Complete()
        //{
        //    Status = BudgetStatuses.COMPLETED;
        //}

    }
}
