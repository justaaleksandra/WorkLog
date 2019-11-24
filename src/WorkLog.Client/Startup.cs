using AutoMapper;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using WorkLog.Client.Profiles;

namespace WorkLog.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(ViewModelEmployeeProfile),
                    typeof(ViewModelWorkTimeProfile),
                    typeof(BllEmployeeProfile),
                    typeof(BllWorkTimeProfile));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}


