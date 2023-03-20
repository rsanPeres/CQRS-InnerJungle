using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Repository.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnerJungle.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
