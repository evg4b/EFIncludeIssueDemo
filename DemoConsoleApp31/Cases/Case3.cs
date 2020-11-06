using System.Threading.Tasks;
using Dotnet31.IncorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utils;

namespace DemoConsoleApp31.Cases
{
    internal static class Case3
    {
        public static async Task Show(IConfiguration configuration)
        {
            UiHelper.Header("Case 3: Query with AsNoTracking:");
            
            await using var context = new IncorrectContext(configuration);
            
            var items2 = await context.Profiles
                .Include(p => p.User)
                .AsNoTracking()
                .ToArrayAsync();
            
            UiHelper.Print("Profiles loaded:", items2);
            
            UiHelper.End();
        }
    }
}