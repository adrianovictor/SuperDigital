using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SuperDigital.Api.Messages.Resource;
using SuperDigital.Api.Queries.Handlers;
using SuperDigital.Api.Queries.Resources;
using SuperDigital.Domain.Model.Accounts;
using SuperDigital.Persistency;
using SuperDigital.Persistency.DataContexts;
using SuperDigital.Persistency.Repositories;
using SuperDigital.Persistency.Repositories.Accounts;
using SuperDigital.QueryProcessor.Dispatcher;
using SuperDigital.QueryProcessor.Query;

namespace SuperDigital.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IRepository, EntityRepository>();
            services.AddScoped<IAccountHolderRepository, AccountHolderRepository>();
            services.AddScoped<IQueryUniqueHandler<QueryAccountHolder, AccountHolderResource>, AccountHolderQueryUniqueHandler>();
            services.AddScoped<IQueryListHandler<QueryMoviment, MovimentResource>, MovimentQueryListHandler>();

            services.AddDbContext<SuperDigitalContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
