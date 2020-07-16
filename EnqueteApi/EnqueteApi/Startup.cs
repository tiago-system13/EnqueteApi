using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AutoMapper;
using bdiApi.Filtros;
using EnqueteApi.AutoMapper;
using EnqueteApi.Core.Constant;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Core.Services;
using EnqueteApi.Core.Services.Interfaces;
using EnqueteApi.Data.Context;
using EnqueteApi.Data.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace EnqueteApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(ExceptionHandlerFilterAttribute)))
             .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(Assembly.Load("EnqueteApi")))
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
               .AddJsonOptions(option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
               .ConfigureApiBehaviorOptions(options =>
               {
                   options.InvalidModelStateResponseFactory = c =>
                   {
                       var errorMessage = c.ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;

                       return new BadRequestObjectResult(new
                       {
                           error = errorMessage
                       });
                   };
               });

            #region Swagger

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info { Title = "Enquete Service API", Version = "V1" });
            });
            #endregion


            #region Conecxão com banco
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EnqueteApiContext>(opt => opt.UseSqlServer(connectionString));

            #endregion

            #region AutoMapper

            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            #endregion

            #region Dependency Injection

            services.AddScoped<IPollRepository, PollRepository>();
            services.AddScoped<IPollService, PollService>();

            services.AddScoped<IOptionsRepository, OptionRepository>();
            services.AddScoped<IOptionsService, OptionsService>();
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                app.UseHttpsRedirection();
            }

            var supportedCultures = new[]
           {
                new CultureInfo("pt-BR")
            };

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });

            app.UseCors(options => options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
            );

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enquete API V1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            //Starting our API in Swagger page
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            //Adding map routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            });

        }
    }
}
