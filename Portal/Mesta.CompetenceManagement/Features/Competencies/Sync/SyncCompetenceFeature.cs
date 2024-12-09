using EFCore.BulkExtensions;
using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Domain.Interfaces;
using Mesta.CompetenceManagement.Persistence;

namespace Mesta.CompetenceManagement.Features.Competencies.Sync
{
    public interface ISyncCompetenceFeature
    {
        Task Execute();
    }

    internal class SyncCompetenceFeature : ISyncCompetenceFeature
    {
        private readonly CompetenceDbContext _competenceDbContext;
        private readonly ICompetenceClient _competenceClient;

        public SyncCompetenceFeature(
            CompetenceDbContext competenceDbContext,
            ICompetenceClient competenceClient)
        {
            _competenceDbContext = competenceDbContext;
            _competenceClient = competenceClient;
        }

        public async Task Execute()
        {
            var skip = 0;
            var list = new List<Competence>();

            while (true)
            {
                var competencies = await _competenceClient.FetchCompetencies(skip);

                await _competenceDbContext.BulkInsertOrUpdateAsync(competencies);

                if (competencies.Count < 1000)
                    break;

                skip = skip + 1000;
            }
        }
    }
}
