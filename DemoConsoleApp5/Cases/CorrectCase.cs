using System.Threading.Tasks;
using Dotnet5.CorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utils;

namespace DemoConsoleApp5.Cases
{
    internal static class CorrectCase
    {
        public static async Task Show(IConfiguration configuration)
        {
            UiHelper.Header("Correct case:");

            await using var context = new CorrectContext(configuration);
            var profiles = await context.Profiles
                .Include(p => p.User)
                .ToArrayAsync();
            
            UiHelper.Print("Loaded profiles:", profiles);
            
            UiHelper.End();
        }
    }
}