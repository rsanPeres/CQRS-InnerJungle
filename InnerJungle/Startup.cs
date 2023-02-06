using InnerJungle.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
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


            services.AddDbContext<ResearchContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("InnerJungleResearches")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InnerJungleResearches", Version = "v1" });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
