using GraphQL.Types;

namespace GQ.Schemas.Budgets
{
    public class BudgetProjectType : ObjectGraphType<BudgetProject>
    {
        public BudgetProjectType()
        {          
            Field(c => c.buD_ProjectID, nullable: true).Description("buD_ProjectID");
            Field(c => c.pmS_PdID, nullable: true).Description("pmS_PdID");
            Field(c => c.pmS_PdMachineryPrice, nullable: true).Description("pmS_PdMachineryPrice");
            Field(c => c.pmS_PdPayPrice, nullable: true).Description("pmS_PdPayPrice");
            Field(c => c.pmS_PdProvideWayId_fk, nullable: true).Description("pmS_PdProvideWayId_fk");
            Field(c => c.projectName, nullable: true).Description("projectName");
            Field(c => c.tbL_BprCode, nullable: true).Description("tbL_BprCode");            
            Field(c => c.tbL_BprDescription, nullable: true).Description("tbL_BprDescription");
            Field(c => c.tbL_BprID, nullable: true).Description("tbL_BprID");
            Field(c => c.tbL_BprID_fk, nullable: true).Description("tbL_BprID_fk");
            Field(c => c.woS_WonName, nullable: true).Description("woS_WonName");
            Field(c => c.woS_WotNote, nullable: true).Description("woS_WotNote");            
        }
       
    }
}
