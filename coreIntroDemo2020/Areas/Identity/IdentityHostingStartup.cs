using System;
using coreIntroDemo2020.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(coreIntroDemo2020.Areas.Identity.IdentityHostingStartup))]
namespace coreIntroDemo2020.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<coreIntroDemo2020Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("coreIntroDemo2020ContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<coreIntroDemo2020Context>();
            });
        }
    }
}