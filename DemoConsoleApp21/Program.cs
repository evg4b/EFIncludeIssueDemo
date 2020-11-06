using System.Threading.Tasks;
using DemoConsoleApp21.Cases;
using Dotnet21.CorrectContext;
using Dotnet21.IncorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoConsoleApp21
{
    internal static class Program
    {
        static async Task Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            await Migrate(configuration);

            await Case1.Show(configuration);
            await Case2.Show(configuration);
            await Case3.Show(configuration);

            await CorrectCase.Show(configuration);
        }


        private static async Task Migrate(IConfiguration configuration)
        {
            using var incorrectContext = new IncorrectContext(configuration);
            await incorrectContext.Database.MigrateAsync();
            
            using var correctContext = new CorrectContext(configuration);
            await correctContext.Database.MigrateAsync();
        }
    }
}
