using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Configurators
{
    public class ExperimentBaseConfigurator : IEntityTypeConfiguration<ExperimentBase>
    {
        public void Configure(EntityTypeBuilder<ExperimentBase> builder)
        {
            builder
                .ToTable("Experiment");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Title).HasColumnType("varchar(50)").IsRequired();

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
