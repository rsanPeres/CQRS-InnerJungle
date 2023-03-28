using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnerJungle.Infra.Configurators
{
    public class ResearchConfigurator : IEntityTypeConfiguration<Research>
    {
        public void Configure(EntityTypeBuilder<Research> builder)
        {
            builder
                .ToTable("Research");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Title).HasColumnType("varchar(50)").IsRequired();

            builder.HasOne(x => x.Institution)
                .WithMany(x => x.Researches);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Researches);
            builder.HasOne(x => x.Eletrode)
                .WithMany(x => x.Researches);

            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
