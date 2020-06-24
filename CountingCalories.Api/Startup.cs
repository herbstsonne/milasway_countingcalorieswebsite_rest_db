using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountingCalories.Api.Controllers;
using EFGetStarted;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEntityFrameworkSqlite()
             .AddDbContext<CountingCaloriesContext>(
                 options => { options.UseSqlite(@$"Data Source={Helper.GetPathOfEntityFrameworkProject(_appHost)}\countingcalories.db"); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
