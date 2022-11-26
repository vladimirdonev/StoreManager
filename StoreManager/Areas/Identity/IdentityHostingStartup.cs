using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(StoreManager.Areas.Identity.IdentityHostingStartup))]
namespace StoreManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}