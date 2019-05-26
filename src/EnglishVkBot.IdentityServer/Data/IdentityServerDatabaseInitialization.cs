using System;
using System.Linq;
using EnglishVkBot.IdentityServer.Models;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EnglishVkBot.IdentityServer.Data
{
    public static class IdentityServerDatabaseInitialization
    {
        public static void InitializeDatabase(IServiceProvider services)
        {
            PerformMigrations(services);
            SeedData(services);
        }

        private static void PerformMigrations(IServiceProvider services)
        {
            services.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            services.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
            services.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
        }

        private static void SeedData(IServiceProvider services)
        {
            var env = services.GetRequiredService<IHostingEnvironment>();
            if (!env.IsDevelopment())
            {
                return;
            }

            var context = services.GetRequiredService<ApplicationDbContext>();

            if (context.Users.FirstOrDefault(u => u.UserName == "admin") != null)
            {
                return;
            }


            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            
            var result = userManager.CreateAsync(new ApplicationUser()
            {
                UserName = "admin",
                Email = "admin@admin.com",
                EmailConfirmed = true
            }, "!QAZ2wsx").GetAwaiter().GetResult();
        }
    }
}