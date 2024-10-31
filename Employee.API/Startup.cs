using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Employee.Repository;
using Employee.Repository.Interfaces;
using Swashbuckle.AspNetCore.Swagger;


namespace Employee.API
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        private static string _connectionString { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                            .AddJsonFile("AppSettings.json");

            _configuration = builder.Build();
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Employee.API",
                });

                var filePath = Path.Combine(AppContext.BaseDirectory, "Transaction.API.xml");
                // c.IncludeXmlComments(filePath);
            });

            services.AddTransient<ICityRepository>(c => new CityRepository(_connectionString));
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1");
            });

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE"));

            app.UseMvc();
        }
    }
}
