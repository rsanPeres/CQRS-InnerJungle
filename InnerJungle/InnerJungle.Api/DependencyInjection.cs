using InnerJungle.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace InnerJungle
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, InnerJungleProblemDetailsFactory>();
            return services;

        }
    }
}
