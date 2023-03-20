using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Configurators
{
    public class ElectrochemicalExperimentConfigurator : IEntityTypeConfiguration<ElectrochemicalExperiment>
    {
        public void Configure(EntityTypeBuilder<ElectrochemicalExperiment> builder)
        {
            builder
                .ToTable("Electrochemical_Experiment");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
