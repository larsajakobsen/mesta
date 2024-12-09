using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mesta.Portal.Application.Tests")]
namespace Mesta.CompetenceManagement.Features.Competencies.Fetch
{
    public interface IFetchCompetenceListFeature
    {
        Task<List<Competence>> Execute();
    }

    internal class FetchCompetenceListFeature : IFetchCompetenceListFeature
    {
        private readonly CompetenceDbContext _dbContext;

        public FetchCompetenceListFeature(
            CompetenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Competence>> Execute()
        {
            return await _dbContext.Competencies.ToListAsync();
        }
    }
}