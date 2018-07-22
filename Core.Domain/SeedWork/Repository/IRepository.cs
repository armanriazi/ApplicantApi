using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.SeedWork.Repository
{
    public interface IRepository : IReadOnlyRepository
    {

        void Add(dynamic entity);
        void Update(dynamic entity);
        bool Delete(dynamic entity);
    }
}
