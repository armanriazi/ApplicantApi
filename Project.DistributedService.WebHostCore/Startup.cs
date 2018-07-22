using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.WebHostCore.Services.Internal;
using Framework.NikExtensions;
using StackExchange.Profiling.Storage;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using GraphQL.Server.Transports.WebSockets;
using GraphQL.Server.Transports.AspNetCore;

namespace Project.DistributedService.WebHostCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;        

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets<Startup>();
                builder.AddApplicationInsightsSettings(developerMode: true);

            }

            //builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }      
      
        // This method gets called by the runtime. Use this method to add services to the container.
        //to configure the built-in container's services
        public void ConfigureServices(IServiceCollection services)
        {


           
            // Add framework services.
            services.AddMvc();
           
            

            //services.AddGraphQLHttp();
            //services.AddGraphQLWebSocket<BankAppSchema>();

            //services.AddSingleton(s => new BankAppSchema());
            // This uses all defaults (e.g. the in-memory error store)
            services.AddExceptional(Configuration.GetSection("Exceptional"));            
            //
            services.AddSwaggerGen(SwaggerHelper.ConfigureSwaggerGen);
            //
            services.AddExceptional(Configuration.GetSection("Exceptional:ErrorStore:ConnectionString"), settings =>
            {               
                settings.UseExceptionalPageOnThrow = HostingEnvironment.IsDevelopment();
            });
            // Note .AddMiniProfiler() returns a IMiniProfilerBuilder for easy intellisense
            services.AddMiniProfiler(options =>
            {
                // All of this is optional. You can simply call .AddMiniProfiler() for all defaults

                // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
                options.RouteBasePath = "/profiler";

                // (Optional) Control storage
                // (default is 30 minutes in MemoryCacheStorage)
                (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);

                // (Optional) Control which SQL formatter to use, InlineFormatter is the default
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();

 
            });



            //var sp = services.BuildServiceProvider();
            //services.AddScoped<ISchema>(_ => new BankAppSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<BANKAppQuery>() });
            //
            //services.AddSingleton<ISchema>(s => new BankAppSchema(type => (GraphType)s.GetService(type)));

            #region NikServicesDIP
            services.AddNikConnection();
            services.AddNikRepository();
            services.AddNikUnitOfWork();            
            #endregion

            #region NikService
            // Register application services.
            services.AddTransient<IBudgetService, BudgetService>();
            services.AddTransient<IProjectManagementSystemService, ProjectManagementSystemService>();
            services.AddTransient<IPriceRepertoryService, PriceRepertoryService>();
            //                      
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var sp = services.BuildServiceProvider();
            //services.AddTransient<ISchema>(_ => new Schema { Query = sp.GetService<BANKAppQuery>() });
            //var sp = services.BuildServiceProvider();
            //services.AddTransient<ISchema>(_ => new Schema { Query = sp.GetService<BANKAppQuery>() });
           // services.AddSingleton<IDependencyResolver>(c=>new FuncDependencyResolver(type=>c.GetRequiredService(type)));           



            //var sp = services.BuildServiceProvider();
            //services.AddSingleton<ISchema>(_ => new BankAppSchema(query : sp.GetService<BANKAppQuery>(), resolver: c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            //services.AddGraphQLHttp();
            //services.AddGraphQLWebSocket<BankAppSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          

            if (env.IsDevelopment())
            {
                app.UseExceptional();               
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Exceptions");
            }

          

            // app.UseMvcWithDefaultRoute();
            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                });
            //app.UseMiddleware<GraphQLMiddleware>(new GraphQLSettings
            //{
            //    BuildUserContext = ctx => new GraphQLUserContext
            //    {
            //        User = ctx.User

            //    }
            //});
            app.UseSwagger(SwaggerHelper.ConfigureSwagger);
            app.UseSwaggerUI(SwaggerHelper.ConfigureSwaggerUI);
            app.UseMiniProfiler();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }


    }
}

