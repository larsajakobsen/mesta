using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Mesta.CompetenceManagement.Features.Competencies.Get;
using Mesta.CompetenceManagement.Features.Competencies.Save;
using Mesta.CompetenceManagement.Features.Competencies.Sync;
using Mesta.CompetenceManagement.Features.Persons.Fetch;
using Mesta.CompetenceManagement.Integrations.Interfaces;
using Mesta.CompetenceManagement.Integrations.Landax;
using Mesta.CompetenceManagement.Integrations.Mdc.Persons;
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
            var competenceConfigurationSection = configuration.GetSection("CompetenceManagement");

            services.AddDbContext<CompetenceDbContext>(options =>
                options.UseSqlServer(competenceConfigurationSection["DatabaseConnectionString"]));

            services.Configure<CompetenceManagementSettings>(competenceConfigurationSection);
            services.Configure<LandaxConfiguration>(configuration.GetSection("Landax"));
            
            services.AddScoped<ICompetenceClient, LandaxClient>();
            services.AddScoped<IPersonClient, MestaPersonsMdcClient>();

            services.AddScoped<IGetCompetenceFeature, GetCompetenceFeature>();
            services.AddScoped<IFetchCompetenceListFeature, FetchCompetenceListFeature>();
            services.AddScoped<ISaveCompetenciesFeature, SaveCompetenciesFeature>();
            services.AddScoped<ISyncCompetenceFeature, SyncCompetenceFeature>();
            services.AddScoped<IFetchPersonsFeature, FetchPersonsFeature>();

            return services;
        }

    }
}
