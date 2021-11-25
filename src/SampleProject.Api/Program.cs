using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, configuration) => {
                var esConfig = new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticsearchConfiguration:Uri"])) {
                    IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    AutoRegisterTemplate = true,
                    NumberOfShards = 2,
                    NumberOfReplicas = 1
                };
                configuration.Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(esConfig)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(context.Configuration);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
