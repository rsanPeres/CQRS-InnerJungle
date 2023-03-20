using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Contexts
{
    public class DBContext : DbContext
    {
        public DbSet<Research> Researches { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
            modelBuilder.Ignore("Notification");
        }

    }
}
