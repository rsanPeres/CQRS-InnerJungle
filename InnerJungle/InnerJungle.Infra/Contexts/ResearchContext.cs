using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Contexts
{
    public class ResearchContext : DbContext
    {
        public DbSet<Research> Researches { get; set; }
        public ResearchContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResearchContext).Assembly);
            modelBuilder.Ignore("Notification");
        }

    }
}
