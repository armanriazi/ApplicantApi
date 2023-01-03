using Core.Domain.EntityDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.SeedWork.POCO.EntityModelDomain
{
  
    public class ProjectManagementSystemReports : BaseEntity
    {
       
        public string BUD_ProjectID { get; set; }
     
        public string ProjectName { get; set; }

        //  PMS_PdID BUD_ProjectID_fk
        //   WHS_WarehouseID_fk WHS_GoodsID_fk  COM_ServiceID_fk TBL_BprID_fk    WOS_WotID_fk WOS_WonID_fk    PMS_PdProvideWayId_fk PMS_PdFirstQuantity PMS_PdQuantity PMS_PdFinalQuantity PMS_PdDeparePrice PMS_PdPayPrice  PMS_PdDisposePrice PMS_PdMaterialPrice PMS_PdMachineryPrice PMS_PdPrice PMS_PdDescription PMS_PdType  PMS_PdNote PMS_PdRegisterDate  PMS_PdActive PMS_PdStatus    PMS_PdDeleteDate ACC_FinancialYearID TBL_UserID TBL_BprID   TBL_BprParentID_fk TBL_PrcID_fk    WHS_GuID_fk TBL_BprCode TBL_BprOldCode TBL_BprDescription  TBL_BprWarehouseCoding TBL_BprTransportCoefficient TBL_BprMaterialPrice TBL_BprPayPrice TBL_BprMachineryPrice TBL_BprDeparePrice1 TBL_BprDeparePrice2 TBL_BprDeparePrice3 TBL_BprMachineryDeparePrice TBL_BprPayDeparePrice   TBL_BprDisposePrice TBL_BprMachineryMovePrice   TBL_BprPayMovePrice TBL_BprPrice    TBL_BprQuantity TBL_BprNote TBL_BprType TBL_BprActive   TBL_BprStatus TBL_BprRegisterDate TBL_BprDeleteDate ACC_FinancialYearID TBL_UserID WOS_WonID   WOS_WonParentID_fk WOS_WonSystemCode   WOS_WonName WOS_WonNote WOS_WonRegisterDate WOS_WonType WOS_WonActive WOS_WonStatus   WOS_WonDeleteDate ACC_FinancialYearID TBL_UserID WOS_WotID   WOS_WotParentID_fk ACC_AcID_fk WOS_WotSystemCode WOS_WotName WOS_WotWageCoefficient WOS_WotNote WOS_WotRegisterDate WOS_WotType WOS_WotActive WOS_WotStatus   WOS_WotDeleteDate ACC_FinancialYearID TBL_UserID WOS_WonName WOS_WotNote Status

        public string WOS_WonName { get; set; }
        public string WOS_WotNote { get; set; }
        public string TBL_BprID { get; set; }
        public string TBL_BprCode { get; set; }
        public string TBL_BprDescription { get; set; }
        public int PMS_PdProvideWayId_fk { get; set; }
        public int PMS_PdFirstQuantity { get; set; }
        public string Status { get; set; }
        public string PMS_PdMaterialPrice { get; set; }
        public string PMS_PdMachineryPrice { get; set; }
        public string PMS_PdPayPrice { get; set; }
        public string PMS_PdPrice { get; set; }
        public string TBL_BprID_fk { get; set; }
        public string PMS_PdID { get; set; }


    }
}
