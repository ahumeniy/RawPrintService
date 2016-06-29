using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace RawPrintService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            if (Debugger.IsAttached)
                basePath = Directory.GetCurrentDirectory();

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("hosting.json", optional: true)
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(basePath)
                .UseStartup<Startup>()
                .Build();

            if (Debugger.IsAttached)
            {
                host.Run();
            }
            else
            {
                host.RunAsService();
            }
        }
    }
}
