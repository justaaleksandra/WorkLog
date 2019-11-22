using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WorkLog.Dal.Repositories;

namespace WorkLog.Dal
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service) =>
            service
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
