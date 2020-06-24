using Microsoft.AspNetCore.Hosting;

namespace CountingCalories.Api
{
    public static class Helper
    {
        public static string GetPathOfEntityFrameworkProject(IWebHostEnvironment appHost)
        {
            return appHost.ContentRootPath.Replace("CountingCalories.Api", "DataAccessEF");
        }
    }
}
