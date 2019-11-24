using Microsoft.Extensions.DependencyInjection;
using WorkLog.Bll.Services;

namespace WorkLog.Bll
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection service) =>
            service
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IWorkTimeService, WorkTimeService>();
    }
}
