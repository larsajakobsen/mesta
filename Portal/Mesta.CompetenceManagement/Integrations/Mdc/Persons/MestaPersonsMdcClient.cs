using Mesta.CompetenceManagement.Configuration;
using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Mesta.CompetenceManagement.Integrations.Mdc.Persons
{
    internal class MestaPersonsMdcClient : IPersonClient
    {
        private static readonly HttpClient _httpClient = new();
        private readonly CompetenceManagementSettings _settings;

        public MestaPersonsMdcClient(IOptions<CompetenceManagementSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            await GetToken();

            //var respons2e = await _httpClient.GetStringAsync($"Persons");
            var response = await _httpClient.GetFromJsonAsync<PersonDto[]>($"Persons");

            var list = response.Select(x => MapToDomainPerson(x));

            return list;
        }

        public async Task<Person> GetPerson(int id)
        {
            await GetToken();

            var response = await _httpClient.GetFromJsonAsync<PersonDto>($"Persons/{id}");

            return MapToDomainPerson(response);
        }

        private static Person MapToDomainPerson(PersonDto x)
        {
            return new Person()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Email = x.Employment.WorkEmail,
                MobilePhone = x.Employment.WorkMobilePhone,
            };
        }

        private async Task GetToken()
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
