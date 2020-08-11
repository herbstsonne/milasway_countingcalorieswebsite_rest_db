using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Infrastructure;
using CountingCalories.Infrastructure.Repository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CountingCalories.Api
{
    public class Startup
    {
        private IWebHostEnvironment _appHost;

        public Startup(IConfiguration configuration, IWebHostEnvironment appHost)
        {
            Configuration = configuration;
            _appHost = appHost;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<ICountCalorieRepository, CountCalorieRepository>();

            services.AddEntityFrameworkSqlite()
             .AddDbContext<CountingCaloriesContext>(
                 (sp, options) =>
                 {
                     options.UseSqlite(
                         @$"Data Source={Helper.GetPathOfEntityFrameworkProject(_appHost)}countingcalories.db"); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
