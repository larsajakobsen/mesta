using Mesta.CompetenceManagement.Configuration;
using Mesta.CompetenceManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Mesta.CompetenceManagement.Persistence
{
    internal class CompetenceDbContext : DbContext
    {
        public DbSet<Competence> Competencies { get; set; }


        private readonly CompetenceManagementSettings _settings;

        public CompetenceDbContext(IOptions<CompetenceManagementSettings> options)
        {
            _settings = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.DatabaseConnectionString);
        }
    }
}
