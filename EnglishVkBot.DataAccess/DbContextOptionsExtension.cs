using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EnglishVkBot.DataAccess
{
    public static class DbContextOptionsExtension
    {
        public static DbContextOptions<DataContext> UseDefaultPostgreSqlOptions(
            this DbContextOptionsBuilder<DataContext> optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            var options = optionsBuilder
                .UseNpgsql(config.GetValue<string>("ConnectionString"))
                .Options;
            return options;
        }
    }
}