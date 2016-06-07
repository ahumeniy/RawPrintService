using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("hosting.json", optional: true)
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(basePath)
                .UseIISIntegration()
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
