using Mesta.CompetenceManagement.Domain.Interfaces;
using Mesta.CompetenceManagement.Domain;

namespace Mesta.CompetenceManagement.Features.Competencies.Get
{
    public interface IGetCompetenceFeature
    {
        Task<Competence> Execute(int id);
    }

    internal class GetCompetenceFeature : IGetCompetenceFeature
    {
        private readonly ICompetenceClient _competenceClient;

        public GetCompetenceFeature(ICompetenceClient competenceClient)
        {
            _competenceClient = competenceClient;
        }

        public async Task<Competence> Execute(int id)
        {
            return await _competenceClient.GetCompetence(id);
        }
    }
}
