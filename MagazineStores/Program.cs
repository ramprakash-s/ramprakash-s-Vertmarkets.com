using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using MagazineStores.Business;
using MagazineStores.Entities;
using MagazineStores.Interfaces;
using MagazineStores.ServiceAgents;
using System.IO;
using MagazineStores.Logging;

namespace MagazineStores
{
    class Program
    {
        static IReadOnlyDictionary<string, string> DefaultConfiguration { get; } =
            new Dictionary<string, string>()
            {
                ["MagezineStore:BaseUrl"] = "http://magazinestore.azurewebsites.net",
                ["MagezineStore:TimeOutInSeconds"] = "20"
            };

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task MainAsync(string[] args)
        {
            try
            {

               // var builder = new ConfigurationBuilder()
               //.SetBasePath(Directory.GetCurrentDirectory())
               //.AddJsonFile("config.json", optional: false);
               // IConfiguration config = builder.Build();

                var builder = new ConfigurationBuilder()
                    .AddInMemoryCollection(DefaultConfiguration)
                    .AddCommandLine(args);

                var config = builder.Build();
                var serviceProvider = new ServiceCollection()
                    .Configure<MagazineStoreConfiguration>(config.GetSection("MagezineStore"))
                    .AddTransient<IMagazineStoreService, MagazineStoreService>()
                    .AddTransient<IMagazineStore, MagazineStore>()
                    //.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>))
                    .BuildServiceProvider();

                var store = serviceProvider.GetService<IMagazineStore>();

                var result = await store.FindsubcribersToAllCategories();
                Console.WriteLine($"Result: {JsonConvert.SerializeObject(result)}");
            }
            catch (Exception)
            {
                Console.WriteLine("An eror as occurred.");
            }


        }
    }
}
