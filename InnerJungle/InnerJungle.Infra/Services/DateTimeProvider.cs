using InnerJungle.Application.Common.Interfaces.Services;

namespace InnerJungle.Infra.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
