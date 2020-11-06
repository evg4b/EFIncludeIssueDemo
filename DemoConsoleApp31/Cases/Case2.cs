using System.Linq;
using System.Threading.Tasks;
using Dotnet31.IncorrectContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utils;

namespace DemoConsoleApp31.Cases
{
    internal static class Case2
    {
        public static async Task Show(IConfiguration configuration)
        {
            UiHelper.Header("Case 2: Select into anonim object:");

            await using var context = new IncorrectContext(configuration);
            
            var profiles = await context.Profiles
                .Include(p => p.User)
                .Select(p => new
                {
                    User = p.User,
                    Profile = p
                })
                .ToArrayAsync();

            UiHelper.Print("Loaded profiles and users :", profiles);

            UiHelper.End();
        }
    }
}