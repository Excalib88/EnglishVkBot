using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EnglishVkBot.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseNpgsql(configuration.GetConnectionString("Db"),
                x => x.MigrationsAssembly(
                        "StaffCertification.Dal.Migrations")
                    .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new DataContext(builder.Options, null);
        }
    }
}