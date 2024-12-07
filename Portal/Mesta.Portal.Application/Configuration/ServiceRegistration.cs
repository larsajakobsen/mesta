﻿using Microsoft.Extensions.DependencyInjection;
using Mesta.CompetenceManagement.Configuration;
using Mesta.ProjectManagement.Configuration;
using Mesta.Portal.Application.Features.Users.Create;
using Microsoft.Extensions.Configuration;
using Mesta.Portal.Application.Features.Competence.Sync;

namespace Mesta.Portal.Application.Configuration
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddMestaPortalApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your services here

            services.AddMestaCompetenceManagement(configuration);
            services.AddMestaProjectManagement();

            services.AddScoped<CreateUserFeature>();
            services.AddScoped<SyncCompetenceFeature>();

            return services;
        }
    }
}
