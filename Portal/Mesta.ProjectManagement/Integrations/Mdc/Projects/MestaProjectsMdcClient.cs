using Mesta.ProjectManagement.Domain;
using Mesta.ProjectManagement.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Identity.Client;
using Mesta.CompetenceManagement.Configuration;
using Microsoft.Extensions.Options;

namespace Mesta.ProjectManagement.Integrations.Mdc.Projects
{
    internal class MestaProjectsMdcClient : IProjectClient
    {
        private static readonly HttpClient _httpClient = new();

        private readonly ProjectManagementSettings _settings;

        public MestaProjectsMdcClient(IOptions<ProjectManagementSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<List<Project>> GetProjects()
        {
            await RefreshToken();

            var response2 = await _httpClient.GetStringAsync($"Projects");
            var response = await _httpClient.GetFromJsonAsync<ProjectDto[]>($"Projects/");

            var list = new List<Project>();

            return list;
        }

        public async Task<Project> GetProject(int id)
        {
            await RefreshToken();

            var response = await _httpClient.GetFromJsonAsync<ProjectDto>($"Projects/{id}");

            return await Task.FromResult(new Project());
        }

        private async Task RefreshToken()
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(_settings.BaseAddress);
                _httpClient.DefaultRequestHeaders.Add("api-version", "1");
            }

            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(_settings.ClientId)
                .WithClientSecret(_settings.ClientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{_settings.TenantId}"))
                .Build();

            var result = await app.AcquireTokenForClient([_settings.Scope]).ExecuteAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
        }
    }
}
