using Mesta.ProjectManagement.Domain.Interfaces;
using Mesta.ProjectManagement.Features.Projects.Fetch;
using Mesta.ProjectManagement.Features.Projects.Get;
using Mesta.ProjectManagement.Integrations.Mdc.Projects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mesta.ProjectManagement.Configuration
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddMestaProjectManagement(this IServiceCollection services, IConfiguration configuration)
        {
            var projectConfigurationSection = configuration.GetSection("ProjectManagement");

            //services.AddDbContext<CompetenceDbContext>(options =>
            //    options.UseSqlServer(competenceConfigurationSection["DatabaseConnectionString"]));

            services.Configure<ProjectManagementSettings>(projectConfigurationSection);

            services.AddScoped<IProjectClient, MestaProjectsMdcClient>();

            services.AddScoped<FetchProjectsFeature>();
            services.AddScoped<GetProjectFeature>();

            return services;
        }
    }
}
