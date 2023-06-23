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
using APIWiltelSoftland.Contexts;
using APIWiltelSoftland.Helpers;
using APIWiltelSoftland.Repositories;
using APIWiltelSoftland.Services;
using APIWiltelSoftland.Entities;
using APIWiltelSoftland.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace APIWiltelSoftland
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
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "APIWiltel", Version = "v1" });
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                config.IncludeXmlComments(xmlpath);
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Ingresar el término 'Bearer', un espacio, y el token de acceso provisto por el endpoint 'Login'
                      Por ejemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                    },
                        new List<string>()
                    }
                });
            });


            services.AddCors();
            services.AddDbContext<WILTELContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddDbContext<WILTELPagosContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("PagosConnectionString")));


            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();
            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltrodeExcepcion));
            }).
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var key = Configuration["key"];
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<APIWiltelLoginRepository>();
            services.AddScoped<APIWiltelLoginService>();

            services.AddScoped<WSCobrosAuthenticationRepository>();
            services.AddScoped<WSCobrosAuthenticationService>();

            services.AddScoped<RecuperarDeudasRepository>();
            services.AddScoped<RecuperarDeudasService>();

            services.AddScoped<PagarDeudasRepository>();
            services.AddScoped<PagarDeudasService>();

            services.AddScoped<ConsultarEstadoTransaccionRepository>();

            services.AddScoped<AnularPagoRepository>();
            services.AddScoped<AnularPagoService>();


            services.AddScoped<ContratoRepository>();
            services.AddScoped<ContratoService>();


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
            //    {
            //        configuration.CreateMap<Cvmcth, ContratoDTO>().ReverseMap();
            //    }
            //    , typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseSoapEndpoint(path: "/PingService.svc", binding: new BasicHttpBinding());

            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("../swagger/v1/swagger.json", "APIWiltel");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
