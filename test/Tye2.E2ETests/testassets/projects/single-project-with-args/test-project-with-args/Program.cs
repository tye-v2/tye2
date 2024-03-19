using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace test_project_with_args
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var argCount = 0;
            foreach (var arg in args)
                Console.WriteLine($"Argument {++argCount}: {arg}");
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
