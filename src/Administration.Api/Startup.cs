using Administration.Domains.Conference.Commands;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Administration.Api.Middlewares;

namespace Administration.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add packages from nuget: "MediatR" and "MediatR.Extensions.Microsoft.DependencyInjection"
            // Middleware for access control
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AccessMiddleware<,>));
            services.AddMediatR(typeof(CreateConferenceCommand).Assembly);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
