namespace Mesta.CompetenceManagement.Domain.Interfaces
{
    public interface ICompetenceClient
    {
        Task<List<Competence>> FetchCompetencies(int skip = 0);
        Task<Competence> GetCompetence(int id);
    }
}
