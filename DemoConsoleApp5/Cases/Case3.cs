using System.Linq;
using System.Threading.Tasks;
using Dotnet5.IncorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utils;

namespace DemoConsoleApp5.Cases
{
    internal static partial class Case3
    {
        public static async Task Show(IConfiguration configuration)
        {
            UiHelper.Header("Query with preloaded users 3 and 5");

            await using var context = new IncorrectContext(configuration);
            
            var userIds = new[] {3, 5};
            var preloadedUsers = await context.Users
                .Where(p => userIds.Contains(p.Id))
                .ToListAsync();

            UiHelper.Print("Preloaded users 3 and 5:", preloadedUsers);
            
            var items = await context.Profiles
                .Include(p => p.User)
                .ToArrayAsync();
            
            UiHelper.Print("Loaded users:", items);
            
            UiHelper.End();
        }
    }
}