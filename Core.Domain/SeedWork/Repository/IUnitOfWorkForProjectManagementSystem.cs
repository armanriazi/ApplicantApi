using Core.Domain.SeedWork.Repository.IEntitysRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.SeedWork.Repository
{

    public interface IUnitOfWorkForProjectManagementSystem : IDisposable
    {      
        IProjectManagementSystemReportRepository ProjectManagementSystemReportRepository { get; }
        void Commit();
    }
}
