using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Mesta.CompetenceManagement.Features.Competencies.Save;

namespace Mesta.Portal.Application.Features.Competence.Sync
{
    public class SyncCompetenceFeature
    {
        private readonly IFetchCompetenceListFeature _fetchCompetenceList;
        private readonly ISaveCompetenciesFeature _saveCompetencies;

        public SyncCompetenceFeature(
            IFetchCompetenceListFeature fetchCompetenceListFeature,
            ISaveCompetenciesFeature saveCompetenciesFeature)
        {
            _fetchCompetenceList = fetchCompetenceListFeature;
            _saveCompetencies = saveCompetenciesFeature;
        }

        public async Task Execute()
        {
            var list = await _fetchCompetenceList.Execute();

            await _saveCompetencies.Execute(list);
        }
    }
}
