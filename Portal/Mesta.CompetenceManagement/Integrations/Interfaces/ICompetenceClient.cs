using Mesta.CompetenceManagement.Domain;

namespace Mesta.CompetenceManagement.Integrations.Interfaces
{
    internal interface ICompetenceClient
    {
        Task<List<Competence>> FetchCompetencies(int skip = 0);
        Task<Competence> GetCompetence(int id);
    }
}
