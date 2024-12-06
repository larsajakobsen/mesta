using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Persistence;

namespace Mesta.CompetenceManagement.Features.Competencies.Save
{
    public interface ISaveCompetenciesFeature
    {
        Task Execute(IEnumerable<Competence> competencies);
    }

    internal class SaveCompetenciesFeature : ISaveCompetenciesFeature
    {
        private readonly CompetenceDbContext _dbContext;

        public SaveCompetenciesFeature(CompetenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(IEnumerable<Competence> competencies)
        {
            await _dbContext.Competencies.AddRangeAsync(competencies.ToArray());

            _dbContext.SaveChanges();
        }
    }
}
