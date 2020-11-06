using System.Threading.Tasks;
using Dotnet21.IncorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utils;

namespace DemoConsoleApp21.Cases
{
    internal static class Case2
    {
        public static async Task Show(IConfiguration configuration)
        {
            UiHelper.Header("Case 2: Query with AsNoTracking");
            
            using var context = new IncorrectContext(configuration);
            
            var items2 = await context.Profiles
                .Include(p => p.User)
                .AsNoTracking()
                .ToArrayAsync();
            
            UiHelper.Print("Profiles loaded:", items2);
            
            UiHelper.End();
        }
    }
}