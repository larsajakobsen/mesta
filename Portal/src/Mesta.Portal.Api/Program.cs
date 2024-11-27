using System.Reflection;
using FluentValidation;
using Mesta.Portal.ServiceDefaults;
using Mesta.Users.Api.Database;
using Mesta.Users.Api.Features;
using Mesta.Users.Api.Gateways.Keycloak;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add database
builder.AddSqlServerDbContext<AppDbContext>("sqlserver");

// Add auth
builder.Services.AddAuthentication()
    .AddKeycloakJwtBearer("keycloak", realm: builder.Configuration["Keycloak:Realm"]!, options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.RequireHttpsMetadata = false;
        }
        options.Audience = "template-api";
    });

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddHealthChecks();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterFeatures();
builder.Services.AddMemoryCache();
builder.Services.AddKeycloak(builder.Configuration);
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add Swagger/OpenApi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        },
    });
});

var app = builder.Build();

// Run migrations
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
// Mac workaround: https://github.com/dotnet/aspire/issues/1023#issuecomment-2156120941
var strategy = new SqlServerRetryingExecutionStrategy(dbContext, 5, TimeSpan.FromSeconds(5), [0]);
await strategy.ExecuteAsync(() => dbContext.Database.MigrateAsync());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePages();

app.MapEndpoints();
app.MapDefaultEndpoints();

app.Run();