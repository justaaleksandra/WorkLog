using AutoMapper;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WorkLog.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(ClientMapperProfile));
        }

        public void Configure(IComponentsApplicationBuilder app) => app.AddComponent<App>("app");
    }
}


