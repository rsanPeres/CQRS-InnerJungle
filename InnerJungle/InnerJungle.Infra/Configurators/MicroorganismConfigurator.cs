using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Configurators
{
    public class MicroorganismConfigurator : IEntityTypeConfiguration<MicroorganismBase>
    {
        public void Configure(EntityTypeBuilder<MicroorganismBase> builder)
        {
            builder
                .ToTable("Microorganism");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(x => x.Species).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(x => x.Family).IsRequired();

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
