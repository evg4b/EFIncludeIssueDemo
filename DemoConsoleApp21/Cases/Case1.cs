using System.Threading.Tasks;
using Dotnet21.IncorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utils;

namespace DemoConsoleApp21.Cases
{
    internal static class Case1
    {
        public static async Task Show(IConfiguration configuration)
        {
            UiHelper.Header("Case 1: Ignore include:");

            using var context = new IncorrectContext(configuration);
            
            var items = await context.Profiles
                .Include(p => p.User)
                .ToArrayAsync();

            UiHelper.Print("Loaded profiles :", items);

            UiHelper.End();
        }
    }
}