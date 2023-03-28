using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Contexts
{
    public class DBContext : DbContext
    {
        public DbSet<Research> Researches { get; set; }
        public DbSet<Nanomaterial> Nanomaterials { get; set; }
        public DbSet<MicroorganismBase> MicroorganismBases { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<ExperimentBase> ExperimentBases { get; set; }
        public DbSet<Eletrode> Eletrodes { get; set; }
        public DbSet<User> Users { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
            modelBuilder.Ignore("Notification");
            modelBuilder.Ignore<Flunt.Notifications.Notification>();
        }

    }
}
