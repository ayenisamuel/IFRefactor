using AcmeStudios.Core.Module.Studio.Concrete;
using AcmeStudios.Core.Module.Studio.Interface;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeStudios.Core
{
    public static class AppBootstrapper
    {
        public static void InitServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IStudioService, StudioService>();
        }
    }
}
