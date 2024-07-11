using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using AcmeStudios.Core;
using Microsoft.EntityFrameworkCore;
using AcmeStudios.Models.Data;
using AcmeStudios.Utilities;

namespace AcemStudios.ApiRefactor
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
            services.AddCors(options =>
             {
                 options.AddPolicy("AllowMyOrigin",
                 builder => builder.WithOrigins("http://localhost:4200")
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 );
             });

            services.AddControllers( options => {
                options.Filters.Add(typeof(ExceptionFilters));
                options.Filters.Add(typeof(ModelValidation));
            });
            AppBootstrapper.InitServices(services);
            services.AddDbContext<Cont>(
                options => options.UseSqlServer("name=ConnectionStrings:StudioConnection"));

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowMyOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllers().RequireCors("AllowMyOrigin");
            });
        }
    }
}
