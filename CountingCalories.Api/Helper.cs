using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;

namespace CountingCalories.Api
{
    public static class Helper
    {
        public static string GetPathOfEntityFrameworkProject(IWebHostEnvironment appHost)
        {
            var path = appHost.ContentRootPath.Replace("CountingCalories.Api", "CountingCalories.Infrastructure");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return path + "/";
            else
                return path + @"\";
        }
    }
}
