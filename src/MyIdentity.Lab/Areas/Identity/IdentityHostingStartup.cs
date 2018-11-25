using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Bookit.Areas.Identity.IdentityHostingStartup))]
namespace Bookit.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}