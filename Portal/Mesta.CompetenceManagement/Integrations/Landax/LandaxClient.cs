using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text;

namespace Mesta.CompetenceManagement.Integrations.Landax;

internal class LandaxClient : ICompetenceClient
{
    private static readonly HttpClient _httpClient = new();
    private readonly LandaxConfiguration _configuration;

    public LandaxClient(IOptions<LandaxConfiguration> options) {
        _configuration = options.Value;
    }

    private void SetupClient()
    {
        var byteArray = Encoding.ASCII.GetBytes($"{_configuration.Username}:{_configuration.Password}");
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Basic", Convert.ToBase64String(byteArray));
    }

    public async Task<List<Competence>> FetchCompetencies(int skip = 0)
    {
        SetupClient();

        var response = await _httpClient.GetFromJsonAsync<LandaxCompetenceResponse>($"https://mesta.landax.no/api/v28/Competencies?skip={skip}");

        return response.value.Select(c => MapLandaxCompetenceToDomain(c)).ToList();
    }

    public async Task<Competence> GetCompetence(int id)
    {
        SetupClient();

        var response = await _httpClient.GetFromJsonAsync<LandaxCompetenceResponse>($"https://mesta.landax.no/api/v28/Competency?filter=Id={id}");

        var landaxCompetence = response.value.Single(c => c.Id == id);

        return MapLandaxCompetenceToDomain(landaxCompetence);
    }

    private static Competence MapLandaxCompetenceToDomain(LandaxCompetence landaxCompetence)
    {
        DateTime? fromDate = ParseDate(landaxCompetence.FromDate);
        DateTime? toDate = ParseDate(landaxCompetence.ToDate);

        return new Competence()
        {
            Id = landaxCompetence.Id,
            EmployeeId = landaxCompetence.CoworkerId,
            Description = landaxCompetence.Description,
            FromDate = fromDate,
            ToDate = toDate,
            Place = landaxCompetence.Place,
            Notes = landaxCompetence.Notes,
            TypeId = landaxCompetence.TypeId,
            Projects = landaxCompetence.Tag3,
            Program = landaxCompetence.Tag2,
            Issuer = landaxCompetence.Tag1,
            Responsible = landaxCompetence.Tag5,
            IsActive = landaxCompetence.IsActive,
            IsValid = landaxCompetence.IsValid,
            IncludeInCV = landaxCompetence.IncludeInCV,
            SendEmailOnExpiring = landaxCompetence.SendEmailOnExpiring,
            StartDate = ParseDate(landaxCompetence.StartDate),
            EndDate = ParseDate(landaxCompetence.EndDate)
        };
    }

    private static DateTime? ParseDate(string dateString)
    {
        DateTime? fromDate = null;
        if (DateTime.TryParse(dateString, out DateTime result))
        {
            fromDate = result;
        };
        return fromDate;
    }
}
