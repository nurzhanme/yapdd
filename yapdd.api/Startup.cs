using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using yapdd.api.Services;
using yapdd.api.Services.Contracts;

namespace yapdd.api
{


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
        {
            public void Apply(ControllerModel controller)
            {
                var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.v1"
                var apiVersion = controllerNamespace?.Split('.').Last().ToLower();

                controller.ApiExplorer.GroupName = apiVersion;
            }
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(c =>
                c.Conventions.Add(
                    new ApiExplorerGroupPerVersionConvention())); // decorate Controllers to distinguish SwaggerDoc (v1, v2, etc.)

            services.AddApiVersioning();
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddControllers();
            
            
            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.FirstOrDefault());
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "YaPdd", Version = "v1", Contact = new OpenApiContact { Name = "Nurzhan Aitbayev", Url = new Uri("https://github.com/nurzhanme")}});
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "YaPdd", Version = "v2", Contact = new OpenApiContact { Name = "Nurzhan Aitbayev", Url = new Uri("https://github.com/nurzhanme") } });
               
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddScoped<IMailService, MailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", $"v2");
            
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
