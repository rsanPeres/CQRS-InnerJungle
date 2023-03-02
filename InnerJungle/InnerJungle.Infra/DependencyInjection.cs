using InnerJungle.Application.Common.Interfaces.Authentication;
using InnerJungle.Application.Common.Interfaces.Services;
using InnerJungle.Infra.Authentication;
using InnerJungle.Infra.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InnerJungle.Application.Common.Interfaces.Persistence;
using InnerJungle.Infra.Persistence;

namespace InnerJungle.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
