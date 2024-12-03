using Mesta.CompetenceManagement.Features.Competencies.Fetch;

namespace Mesta.Portal.Application.Features.Competence.Sync
{
    public class SyncCompetenceFeature
    {
        private readonly IFetchCompetenceListFeature _fetchCompetenceListFeature;

        public SyncCompetenceFeature(IFetchCompetenceListFeature fetchCompetenceListFeature)
        {
            _fetchCompetenceListFeature = fetchCompetenceListFeature;
        }

        public async Task Execute()
        {
            var list = await _fetchCompetenceListFeature.Execute();
        }
    }
}
