using AutoMapper;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using WorkLog.Bll;
using WorkLog.Bll.Profiles;
using WorkLog.Client.Profiles;
using WorkLog.Dal;

namespace WorkLog.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(ViewModelEmployeeProfile));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}


