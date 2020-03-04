using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DockerComposeApiDb01.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeApiDb01
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "192.168.99.100";
            // var server = Configuration["DBServer"] ?? "ms-sql-server";

            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Passw0rd2020";

            var database = Configuration["Database"] ?? "Colours";

            var connectionString = $"Server={server},{port};Database={database};User Id={user};Password={password}";

            // ConfigureServices
            Console.WriteLine($"ConfigureServices=[START]");

            Console.WriteLine($"server=[{server}]");
            Console.WriteLine($"port=[{port}]");
            Console.WriteLine($"user=[{user}]");
            Console.WriteLine($"password=[{password}]");
            Console.WriteLine($"database=[{database}]");

            Console.WriteLine($"connectionString=[{connectionString}]");

            Console.WriteLine($"ConfigureServices=[END]");

            services.AddDbContext<ColourContext>(
                options => options.UseSqlServer(connectionString));

            // services.AddControllers();
            services
                .AddControllers()
                // .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = _environment.IsDevelopment());
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDB.PrepPopulation(app);
        }
    }
}
