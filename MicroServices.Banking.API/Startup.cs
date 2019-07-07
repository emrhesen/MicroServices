using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MicroServices.Banking.Data.Context;
using MicroServices.Infra.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace MicroServices.Banking.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BankingDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("BankingDbConnection"));
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1",new Info { Title = "Banking MicroServices" , Version = "v1"});
            });

            services.AddMediatR(typeof(Startup));

            RegisteredServices(services);
        }

        private void RegisteredServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json","Banking MicroService V1");
            });



            app.UseMvc();
        }
    }
}
