using Mesta.ProjectManagement.Features.Projects.Fetch;
using Mesta.ProjectManagement.Features.Projects.Get;
using Microsoft.Extensions.DependencyInjection;

namespace Mesta.ProjectManagement.Configuration
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddMestaProjectManagement(this IServiceCollection services)
        {
            // Register your services here

            services.AddScoped<FetchProjectsFeature>();
            services.AddScoped<GetProjectFeature>();

            return services;
        }
    }
}
