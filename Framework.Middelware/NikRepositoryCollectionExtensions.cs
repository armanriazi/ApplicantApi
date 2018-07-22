using Core.Domain.SeedWork.Repository.IEntitysRepository;
using Core.ProjectInfrastructure.Persistence.RepositoryImplement.EntitiesRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.NikExtensions
{
    public static class NikRepositoryCollectionExtensions
    {
        public static IServiceCollection AddNikRepository(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Scoped(typeof(IBudgetProjectRepository), typeof(BudgetProjectRepository)));
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IProjectManagementSystemReportRepository), typeof(ProjectManagementSystemRepository)));
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IPriceRepertoryRepository), typeof(PriceRepertoryRepository)));

            return services;
        }
    }
}
