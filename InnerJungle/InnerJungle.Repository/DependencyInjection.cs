using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Repository.Configuration;
using InnerJungle.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InnerJungle.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IResearchRepository, ResearchRepository>();
            return services;
        }
    }
}
