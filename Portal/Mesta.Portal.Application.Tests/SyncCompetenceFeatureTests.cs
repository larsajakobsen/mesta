using FakeItEasy;
using Mesta.CompetenceManagement.Domain;
using Mesta.CompetenceManagement.Domain.Interfaces;
using Mesta.CompetenceManagement.Features.Competencies.Fetch;
using Mesta.CompetenceManagement.Features.Competencies.Save;
using Mesta.CompetenceManagement.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mesta.Portal.Application.Tests
{
    public class SyncCompetenceFeatureTests
    {
        //[Fact]
        //public async Task Execute_WithNoParams_ShouldFetchCompetenceAndSave()
        //{
        //    ICompetenceClient competenceClient = A.Fake<ICompetenceClient>();
        //    IPersonClient personClient = A.Fake<IPersonClient>();

        //    A.CallTo(() => competenceClient.FetchCompetencies()).Returns(GetFakeCompetencies());

        //    var options = new DbContextOptionsBuilder<CompetenceDbContext>()
        //        .UseInMemoryDatabase("CompetenceTestDb")
        //        .Options;

        //    using var dbContext = new CompetenceDbContext(options);

        //    IFetchCompetenceListFeature fetchCompetenceList = new FetchCompetenceListFeature(dbContext, personClient, competenceClient);
        //    ISaveCompetenciesFeature saveCompetencies = new SaveCompetenciesFeature(dbContext);

        //    SyncCompetenceFeature sut = new(fetchCompetenceList, saveCompetencies);

        //    await sut.Execute();

        //    A.CallTo(() => competenceClient.FetchCompetencies()).MustHaveHappened();

        //    Assert.Equal(4, dbContext.Competencies.Count());
        //}

        private static List<Competence> GetFakeCompetencies()
        {
            return new List<Competence>
                {           new Competence
            {
                Id = 1,
                PersonName = "Ola Nordmann",
                TypeId = 101,
                Type = "Sertifisering",
                Status = "Gyldig",
                Description = "Sertifisert innen arbeid på jernbanespor",
                Place = "Oslo",
                StartDate = DateTime.Now.AddYears(-3),
                EndDate = DateTime.Now.AddMonths(6),
                FromDate = null,
                ToDate = null,
                Notes = "Kreves for arbeid på NSB-prosjekter",
                Projects = "Sporfornyelse 2024",
                Program = "Jernbaneutvikling",
                Issuer = "Statens Jernbanetilsyn",
                Responsible = "Prosjektleder",
                IsActive = true,
                IsValid = true,
                SendEmailOnExpiring = true,
                IncludeInCV = true
            },
            new Competence
            {
                Id = 2,
                PersonName = "Kari Nordmann",
                TypeId = 102,
                Type = "Opplæring",
                Status = "Fullført",
                Description = "Grunnleggende kurs i veiarbeid og sikkerhet",
                Place = "Bergen",
                StartDate = DateTime.Now.AddYears(-1),
                EndDate = null,
                FromDate = null,
                ToDate = null,
                Notes = "Kurset inkluderer arbeid på høyrisikoområder",
                Projects = "E39 Utvidelsesprosjekt",
                Program = "Veiarbeiderutdanning",
                Issuer = "Statens Vegvesen",
                Responsible = "Kursinstruktør",
                IsActive = true,
                IsValid = true,
                SendEmailOnExpiring = false,
                IncludeInCV = true
            },
            new Competence
            {
                Id = 3,
                PersonName = "Per Hansen",
                TypeId = 103,
                Type = "Fagbrev",
                Status = "Gyldig",
                Description = "Fagbrev i betongarbeid for infrastruktur",
                Place = "Trondheim",
                StartDate = DateTime.Now.AddYears(-5),
                EndDate = DateTime.Now.AddYears(5),
                FromDate = null,
                ToDate = null,
                Notes = "Krav for arbeid på store bro- og tunnelprosjekter",
                Projects = "Fergefri E39",
                Program = "Fagarbeiderutdanning",
                Issuer = "Bygg- og Anleggsforbundet",
                Responsible = "Opplæringsansvarlig",
                IsActive = true,
                IsValid = true,
                SendEmailOnExpiring = true,
                IncludeInCV = true
            },
            new Competence
            {
                Id = 4,
                PersonName = "Lise Johansen",
                TypeId = 104,
                Type = "Kurs",
                Status = "Utgått",
                Description = "Sikkerhetskurs for arbeid i nærheten av trafikk",
                Place = "Stavanger",
                StartDate = DateTime.Now.AddYears(-4),
                EndDate = DateTime.Now.AddMonths(-2),
                FromDate = null,
                ToDate = null,
                Notes = "Bør fornyes for nye prosjekter",
                Projects = "E18 Sikkerhetssone",
                Program = "Sikkerhetsopplæring",
                Issuer = "Statens Vegvesen",
                Responsible = "Prosjektkoordinator",
                IsActive = false,
                IsValid = false,
                SendEmailOnExpiring = false,
                IncludeInCV = false
            }
                };
        }
    }
}