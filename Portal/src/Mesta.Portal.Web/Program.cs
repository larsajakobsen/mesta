

using Mesta.Portal.Application.Configuration;
using Mesta.Portal.ServiceDefaults;
using Mesta.Portal.Web;
using Mesta.Users.Api.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MudBlazor.Services;
using Refit;
using SmartComponents.Inference.OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add auth
const string oidcScheme = OpenIdConnectDefaults.AuthenticationScheme;
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        if (!builder.Environment.IsDevelopment())
        {
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        }
    })
    .AddKeycloakOpenIdConnect(
        serviceName: "keycloak",
        realm: builder.Configuration["Authentication:Realm"]!,
        authenticationScheme: oidcScheme,
        options =>
        {
            options.ClientId = builder.Configuration["Authentication:ClientId"];
            options.ResponseType = OpenIdConnectResponseType.Code;

            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");

            options.SkipUnrecognizedRequests = true;
            options.ResponseType = OpenIdConnectResponseType.Code;
            options.SaveTokens = true;

            if (builder.Environment.IsDevelopment())
            {
                options.RequireHttpsMetadata = false;
                options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.None;
                options.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
                options.ProtocolValidator.RequireNonce = false;
            }
        }
    );

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthorizationMessageHandler>();
builder.Services
    .AddRefitClient<IUserApi>()
    .AddHttpMessageHandler<AuthorizationMessageHandler>()
    .ConfigureHttpClient(client => client.BaseAddress = new(builder.Configuration["ApiUrl"]!));

builder.Services.AddMestaPortalApplication(builder.Configuration);

builder.Services.AddSmartComponents()
    .WithInferenceBackend<OpenAIInferenceBackend>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseHttpsRedirection();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();