namespace Mesta.CompetenceManagement.Domain.Interfaces
{
    internal interface ICompetenceClient
    {
        Task<List<Competence>> FetchCompetencies();
        Task<Competence> GetCompetence(int id);
    }
}
