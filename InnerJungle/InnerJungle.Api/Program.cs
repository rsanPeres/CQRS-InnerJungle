using InnerJungle;
using InnerJungle.Application;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Infra;
using InnerJungle.Infra.Contexts;
using InnerJungle.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace InneJungle;
class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            builder.Services
                .AddApplication()
                .AddPresentation()
                .AddRepository()
                .AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<IResearchRepository>>();
            builder.Services.AddSingleton(typeof(ILogger), logger);

            using IHost host = Host.CreateDefaultBuilder().Build();
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

            builder.Services.AddDbContextPool<DBContext>(opt => opt.UseSqlServer(config.GetConnectionString("innerJungle")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InnerJungleResearches", Version = "v1" });
            });

        }


        var app = builder.Build();
        {
            app.UseExceptionHandler("/error");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}