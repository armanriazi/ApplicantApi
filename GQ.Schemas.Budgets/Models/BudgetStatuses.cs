using System;
using System.Collections.Generic;
using System.Text;

namespace GQ.Schemas.Budgets
{
    [Flags]
    public enum BudgetStatuses
    {
        CREATED = 2,
        PROCESSING = 4,
        COMPLETED = 8,
        CANCELLED = 16,
        CLOSED = 32
    }
}
