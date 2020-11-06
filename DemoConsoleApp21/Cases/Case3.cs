using System.Threading.Tasks;
using Dotnet21.IncorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utils;

namespace DemoConsoleApp21.Cases
{
    internal static class Case3
    {
        public static async Task Show(IConfiguration configuration)
        {
            UiHelper.Header("Case 3: [not reproduced] Query with AsNoTracking:");
            
            using var context = new IncorrectContext(configuration);
            
            var profiles = await context.Profiles
                .Include(p => p.User)
                .AsNoTracking()
                .ToArrayAsync();
            
            UiHelper.Print("Profiles loaded:", profiles);
            
            UiHelper.End();
        }
    }
}