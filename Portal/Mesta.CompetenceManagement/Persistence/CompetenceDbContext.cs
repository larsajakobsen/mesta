using Mesta.CompetenceManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mesta.CompetenceManagement.Persistence
{
    internal class CompetenceDbContext : DbContext
    {
        public DbSet<Competence> Competencies { get; set; }

       public CompetenceDbContext(DbContextOptions<CompetenceDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LARSJOBB\\SQLEXPRESS;Database=Mesta.Competence;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competence>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Competence>()
                .Property(e => e.Id)
                .ValueGeneratedNever(); 
        }
    }
}
