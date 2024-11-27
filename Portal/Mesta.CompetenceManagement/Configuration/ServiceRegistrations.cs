using Mesta.CompetenceManagement.Domain.Interfaces;
using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Mesta.CompetenceManagement.Features.Competencies.Get;
using Mesta.CompetenceManagement.Integrations.Landax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mesta.CompetenceManagement.Configuration
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddMestaCompetenceManagement(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your services here

            services.Configure<LandaxConfiguration>(configuration.GetSection("Landax"));

            services.AddScoped<IGetCompetenceFeature, GetCompetenceFeature>();
            services.AddScoped<IFetchCompetenceListFeature, FetchCompetenceListFeature>();
            services.AddScoped<ICompetenceClient, LandaxClient>();

            return services;
        }
    }
}
