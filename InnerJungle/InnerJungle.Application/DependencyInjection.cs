using InnerJungle.Application.Services.Authentication.Commands;
using InnerJungle.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace InnerJungle.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService,AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}
