using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Configurators
{
    public class NanomaterialConfigurator : IEntityTypeConfiguration<Nanomaterial>
    {
        public void Configure(EntityTypeBuilder<Nanomaterial> builder)
        {
            builder
                .ToTable("Nanomaterial");
            builder
                .HasKey(x => x.Id);

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
