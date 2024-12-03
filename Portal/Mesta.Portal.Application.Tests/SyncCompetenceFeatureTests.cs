using FakeItEasy;
using Mesta.CompetenceManagement.Domain.Interfaces;
using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Mesta.Portal.Application.Features.Competence.Sync;

namespace Mesta.Portal.Application.Tests
{
    public class SyncCompetenceFeatureTests
    {
        [Fact]
        public async Task Execute_WithNoParams_ShouldFetchCompetenceAndSave()
        {
            ICompetenceClient competenceClient = A.Fake<ICompetenceClient>();

            A.CallTo(() => competenceClient.FetchCompetencies()).Returns(
                new List<CompetenceManagement.Domain.Competence>            
                {
                    new CompetenceManagement.Domain.Competence()
                    {
                        Id = 1,
                        Description = "Førerkort klasse C",
                    }
                });

            IFetchCompetenceListFeature fetchCompetenceList = new FetchCompetenceListFeature(competenceClient);

            SyncCompetenceFeature sut = new(fetchCompetenceList);

            await sut.Execute();

            A.CallTo(() => competenceClient.FetchCompetencies()).MustHaveHappened();
        }
    }
}