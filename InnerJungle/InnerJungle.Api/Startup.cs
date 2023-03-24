using InnerJungle.Application;
using InnerJungle.Common.Errors;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Handlers;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Infra;
using InnerJungle.Infra.Contexts;
using InnerJungle.Repository;
using InnerJungle.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace InnerJungle
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
            services.AddControllers();

            services.AddDbContextPool<DBContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("innerJungle")));

            services.AddSingleton<ProblemDetailsFactory, InnerJungleProblemDetailsFactory>();
            services.AddTransient<IResearchRepository, ResearchRepository>();
            services.AddTransient<IHandler<CreateResearchCommand>, CreateResearchHandler>();
            services.AddTransient<IHandler<UpdateResearchCommand>, UpdateResearchHandler>();
            services.AddTransient<IHandler<MarkResearchAsDoneCommand>, ResearchDoneHandler>();
            services.AddTransient<IHandler<MarkResearchAsUnDoneCommand>, ResearchUndoneHandler>();
            services.AddInfrastructure();
            services.AddApplication();
            services.AddRepository();

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<IResearchRepository>>();
            services.AddSingleton(typeof(ILogger), logger);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InnerJungleResearches", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(op =>
                    {
                        op.Authority = "https://securetoken.google.com/project-5642768471246822332";
                        op.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = "https://securetoken.google.com/project-5642768471246822332",
                            ValidateAudience = true,
                            ValidAudience = "project-5642768471246822332",
                            ValidateLifetime = true
                        };
                    });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "InnerJungleResearches v1"));
            }
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
