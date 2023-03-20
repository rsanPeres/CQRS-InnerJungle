using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Configurators
{
    public class EletrodeConfigurator : IEntityTypeConfiguration<Eletrode>
    {
        public void Configure(EntityTypeBuilder<Eletrode> builder)
        {
            builder
                .ToTable("Eletrode");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(x => x.Type).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(x => x.Amount).IsRequired();

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
