using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Domain.Interfaces;

namespace Mesta.CompetenceManagement.Features.Competencies.Fetch
{
    public interface IFetchCompetenceListFeature
    {
        Task<List<Competence>> Execute();
    }

    internal class FetchCompetenceListFeature : IFetchCompetenceListFeature
    {
        private readonly ICompetenceClient _competenceClient;

        public FetchCompetenceListFeature(ICompetenceClient competenceClient)
        {
            _competenceClient = competenceClient;
        }

        public async Task<List<Competence>> Execute()
        {
            return await _competenceClient.FetchCompetencies();
        }
    }
}