using Core.Domain.SeedWork.Repository.IEntitysRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.SeedWork.Repository
{

    public interface IUnitOfWorkForBudget : IDisposable
    {
        IBudgetProjectRepository BudgetProjectRepository { get; }
        void Commit();
    }
}
