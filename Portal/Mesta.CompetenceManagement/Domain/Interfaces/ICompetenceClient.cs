namespace Mesta.CompetenceManagement.Domain.Interfaces
{
    public interface ICompetenceClient
    {
        Task<List<Competence>> FetchCompetencies();
        Task<Competence> GetCompetence(int id);
    }
}
