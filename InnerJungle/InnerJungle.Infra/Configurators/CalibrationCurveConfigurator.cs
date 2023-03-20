using InnerJungle.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Infra.Configurators
{
    public class CalibrationCurveConfigurator : IEntityTypeConfiguration<CalibrationCurve>
    {
        public void Configure(EntityTypeBuilder<CalibrationCurve> builder)
        {
            builder
                .ToTable("Calibration_Curve");
            builder
                .Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();

            builder.Ignore(x => x.IsValid);
        }
    }
}
