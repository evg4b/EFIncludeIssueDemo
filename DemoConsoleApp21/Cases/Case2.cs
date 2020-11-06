using System.Linq;
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
            UiHelper.Header("Case 2: [not reproduced] Select into anonim object:");

            using var context = new IncorrectContext(configuration);
            
            var profiles = await context.Profiles
                .Include(p => p.User)
                .Select(p => new
                {
                    User = p.User,
                    Profile = p
                })
                .ToArrayAsync();

            UiHelper.Print("Loaded profiles :", profiles);

            UiHelper.End();
        }
    }
}