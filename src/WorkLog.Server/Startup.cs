using AutoMapper;
using WorkLog.Bll;
using WorkLog.Dal;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WorkLog.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services
                .AddResponseCompression(opts =>
                {
                    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] {"application/octet-stream"});
                })
                .AddAutoMapper(typeof(BllMapperProfile))
                .AddDbContext<WorkLogContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString(nameof(WorkLogContext))))
                .AddRepositories()
                .AddServices();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
