using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnerJungle.Infra.Configurators
{
    public class UserConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User");
            builder
                .Property(e => e.Email).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(x => x.FirstName).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property (x => x.LastName).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(x => x.Password).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
