using GraphQL.Types;

namespace GQ.Schemas.Budgets
{
    public class BudgetProjectQuery : ObjectGraphType<object>
    {
        public BudgetProjectQuery(IBudgetProjectService budgetProjectService)
        {
            Name = "Query";
            Field<ListGraphType<BudgetProjectType>>(
                "BudgetAll",
                resolve: context => budgetProjectService.GetAsync()
            );
            Field<ListGraphType<BudgetProjectType>>(
                   "BudgetByMeliCode",
                   Description = "This field returns the projects of the submitted melicode",
                   arguments: new QueryArguments(
                              new QueryArgument<StringGraphType> { Name = "melicode" }
                   ),
                     resolve: context => budgetProjectService.Get(context.GetArgument<string>("melicode"))
               );

            
        }
    }
}
