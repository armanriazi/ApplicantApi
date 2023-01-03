using GraphQL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GQ.Schemas.Budgets
{
    public static class NikGraphQLCollectionExtensions
    {

        public static IServiceCollection AddNikGraphQL(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Singleton(typeof(IBudgetProjectService), typeof(BudgetProjectService)));
            services.TryAdd(ServiceDescriptor.Singleton(typeof(BudgetProjectSchema)));
            services.TryAdd(ServiceDescriptor.Singleton(typeof(BudgetProjectQuery)));
            services.TryAdd(ServiceDescriptor.Singleton(typeof(BudgetProjectType)));
            services.AddSingleton<IDependencyResolver>(c =>new FuncDependencyResolver(type => c.GetRequiredService(type))); 

            return services;
        }
    }
}
