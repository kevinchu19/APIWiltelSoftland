using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Serilog;
using WSCobrosSoftland.Contexts;
using WSCobrosSoftland.Helpers;
using WSCobrosSoftland.Repositories;
using WSCobrosSoftland.Services;

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
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{ Title = "WSCobros", Version = "v1" });
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                config.IncludeXmlComments(xmlpath);
            });

            
            services.AddCors();
            services.AddDbContext<WILTELContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();
            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltrodeExcepcion));
            }).
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<WSCobrosAuthenticationRepository>();
            services.AddScoped<WSCobrosAuthenticationService>();

            services.AddScoped<RecuperarDeudasRepository>();
            services.AddScoped<RecuperarDeudasService>();

            services.AddScoped<PagarDeudasRepository>();
            services.AddScoped<PagarDeudasService>();

            services.AddScoped<ConsultarEstadoTransaccionRepository>();

            services.AddScoped<AnularPagoRepository>();
            services.AddScoped<AnularPagoService>();

            services.AddSingleton<Serilog.ILogger>(options =>
            {
                var connstring = Configuration["Serilog:SerilogConnectionString"];
                var tableName = Configuration["Serilog:TableName"];
                return new LoggerConfiguration().WriteTo.
                MSSqlServer(connstring, tableName,
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                autoCreateSqlTable: true).CreateLogger();
            });
            //services.AddAutoMapper(configuration => 
            //    configuration.CreateMap<>
            //    ,typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("../swagger/v1/swagger.json", "WSCobros");
            });

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
