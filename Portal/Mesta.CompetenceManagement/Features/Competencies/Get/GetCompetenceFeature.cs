using Mesta.CompetenceManagement.Domain.Interfaces;
using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mesta.CompetenceManagement.Features.Competencies.Get
{
    public interface IGetCompetenceFeature
    {
        Task<Competence> Execute(int id);
    }

    internal class GetCompetenceFeature : IGetCompetenceFeature
    {
        private readonly CompetenceDbContext _dbContext;

        public GetCompetenceFeature(CompetenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Competence> Execute(int id)
        {
            return await _dbContext.Competencies.SingleAsync(c => c.Id == id);
        }
    }
}
