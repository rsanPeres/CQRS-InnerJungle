using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Property(x => x.User).HasColumnType("varchar(50)").IsRequired();
            builder
                .Property(x => x.Title).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
