using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace webng2
{
    public class Program
    {
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration

        public static void Main(string[] args)
        {
            //http://andrewlock.net/configuring-urls-with-kestrel-iis-and-iis-express-with-asp-net-core/

            /*
             * Method 1: Specify hosting.json
             * {
             *    "server.urls": "http://localhost:8000"
             * }
             */
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("hosting.json", optional: true)
            //    .Build();

            /*
             * Method 2: Specify through command line arguments
             *    --server.urls http://localhost:7000
             * See launchSettings.json
             */
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        //        RuntimeEnvironment runtime = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Runtime;
        //        Microsoft.Extensions.PlatformAbstractions.ApplicationEnvironment env = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application;
        //        System.Console.WriteLine($@"
        //IApplicationEnvironment:
        //        Base Path:      {env.ApplicationBasePath}
        //        App Name:       {env.ApplicationName}
        //        App Version:    {env.ApplicationVersion}
        //        Runtime:        {env.RuntimeFramework}
        //IRuntimeEnvironment:
        //        OS:             {runtime.OperatingSystem}
        //        OS Version:     {runtime.OperatingSystemVersion}
        //        Architecture:   {runtime.RuntimeArchitecture}
        //        Path:           {runtime.RuntimePath}
        //        Type:           {runtime.RuntimeType}
        //        Version:        {runtime.RuntimeVersion}");
    }
}
