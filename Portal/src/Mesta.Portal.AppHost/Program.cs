using Aspire.Hosting;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = DistributedApplication.CreateBuilder(args);

// sql
var sqlPassword = builder.AddParameter("SqlPassword", secret: true);
var sqlserver = builder
    .AddSqlServer("sqlserver", password: sqlPassword)
    .WithDataVolume()
    .WithHttpEndpoint(1433, 1433);

var competenceDb = sqlserver.AddDatabase("CompetenceDatabase");

// keycloak
var keycloakAdmin = builder.AddParameter("KeycloakAdmin", secret: true);
var keycloakPassword = builder.AddParameter("KeycloakPassword", secret: true);
var keycloak = builder
    .AddKeycloak("keycloak", 51188, keycloakAdmin, keycloakPassword)
    .WithDataVolume();

if (builder.Environment.IsDevelopment())
{
    keycloak.WithRealmImport("realms");
}

// api
var apiService = builder
    .AddProject<Projects.Mesta_Users_Api>("apiservice")
    .WithReference(keycloak)
    .WithReference(sqlserver);

// client
builder.AddProject<Projects.Mesta_Portal_Web>("webclient")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak)
    .WithReference(apiService)
    .WithReference(competenceDb);

// maildev
if (builder.Environment.IsDevelopment())
{
    builder.AddContainer("maildev", "maildev/maildev")
        .WithHttpEndpoint(1080, 1080, "web")
        .WithHttpEndpoint(1025, 1025, "mail");
}

builder.AddProject<Projects.Mesta_Portal_Functions>("mesta-portal-functions")
    .WithExternalHttpEndpoints();

builder.Build().Run();