using InnerJungle.Application;
using InnerJungle.Domain;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Infra;
using InnerJungle.Infra.Contexts;
using InnerJungle.Provider;
using InnerJungle.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace InnerJungle;
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
                .AddDomain()
                .AddInfrastructure(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<IResearchRepository>>();
            builder.Services.AddSingleton(typeof(ILogger), logger);


            builder.Services.AddDbContext<DBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("innerJungle")));

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