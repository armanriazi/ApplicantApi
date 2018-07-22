using GraphQL;
using GraphQL.Types;

namespace GQ.Schemas.Budgets
{
    public class BudgetProjectSchema : Schema
    {
        public BudgetProjectSchema(BudgetProjectQuery query, IDependencyResolver  resolver)
        {
            Query = query;
            DependencyResolver = resolver;            
        }      
    }

}
