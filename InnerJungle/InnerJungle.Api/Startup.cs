using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Handlers;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces;
using InnerJungle.Infra.Contexts;
using InnerJungle.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace InnerJungle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddDbContextPool<ResearchContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("innerJungle")));

            services.AddTransient<IResearchRepository, ResearchRepository>();
            services.AddTransient<IHandler<CreateResearchCommand>, CreateResearchHandler>();
            services.AddTransient<IHandler<UpdateResearchCommand>, UpdateResearchHandler>();
            services.AddTransient<IHandler<MarkResearchAsDoneCommand>, ResearchDoneHandler>();
            services.AddTransient<IHandler<MarkResearchAsUnDoneCommand>, ResearchUndoneHandler>();


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
