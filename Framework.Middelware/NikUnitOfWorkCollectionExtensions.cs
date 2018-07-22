using Core.Domain.SeedWork.Repository;
using Core.ProjectInfrastructure.Persistence.RepositoryImplement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.NikExtensions
{
 
    public static class NikUnitOfWorkCollectionExtensions
    {

        public static IServiceCollection AddNikUnitOfWork(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Scoped(typeof(IUnitOfWorkForProjectManagementSystem), typeof(UnitOfWorkForProjectManagementSystem)));
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IUnitOfWorkForBudget), typeof(UnitOfWorkForBudget)));
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IUnitOfWorkForPriceRepertory), typeof(UnitOfWorkForPriceRepertory)));

            return services;
        }
    }
}
