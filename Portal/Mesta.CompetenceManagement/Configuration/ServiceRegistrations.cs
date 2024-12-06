using Mesta.CompetenceManagement.Domain.Interfaces;
using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Mesta.CompetenceManagement.Features.Competencies.Get;
using Mesta.CompetenceManagement.Features.Competencies.Save;
using Mesta.CompetenceManagement.Integrations.Landax;
using Mesta.CompetenceManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mesta.CompetenceManagement.Configuration
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddMestaCompetenceManagement(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CompetenceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CompetenceManagement:DatabaseConnectionString")));

            services.Configure<CompetenceManagementSettings>(configuration.GetSection("CompetenceManagement"));
            services.Configure<LandaxConfiguration>(configuration.GetSection("Landax"));

            services.AddScoped<IGetCompetenceFeature, GetCompetenceFeature>();
            services.AddScoped<IFetchCompetenceListFeature, FetchCompetenceListFeature>();
            services.AddScoped<ISaveCompetenciesFeature, SaveCompetenciesFeature>();
            services.AddScoped<ICompetenceClient, LandaxClient>();

            return services;
        }
    }
}
