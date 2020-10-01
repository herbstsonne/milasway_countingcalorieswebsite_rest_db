using CountingCalories.DataAccess;
using CountingCalories.DataAccess.Repository.Implementation;
using CountingCalories.Domain.Repository.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CountingCalories.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _appHost;

        public Startup(IWebHostEnvironment appHost)
        {
            _appHost = appHost;
        }

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
