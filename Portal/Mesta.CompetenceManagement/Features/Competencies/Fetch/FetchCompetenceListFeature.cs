using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mesta.Portal.Application.Tests")]
namespace Mesta.CompetenceManagement.Features.Competencies.Fetch
{
    public interface IFetchCompetenceListFeature
    {
        Task<IList<Competence>> Execute(int take);
    }

    internal class FetchCompetenceListFeature : IFetchCompetenceListFeature
    {
        private readonly CompetenceDbContext _dbContext;

        public FetchCompetenceListFeature(
            CompetenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Competence>> Execute(int take)
        {
            return await _dbContext.Competencies
                .OrderByDescending(c => c.Id)
                .Take(take)
                .ToListAsync();
        }
    }
}