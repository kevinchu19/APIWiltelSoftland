using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Repositories;

namespace WSCobrosSoftland
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
            services.AddCors();
            services.AddDbContext<WILTELContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();
            services.AddMvc().
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<RecuperarDeudasRepository>();
            services.AddScoped<PagarDeudasRepository>();
            //services.AddAutoMapper(configuration => 
            //    configuration.CreateMap<>
            //    ,typeof(Startup));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
