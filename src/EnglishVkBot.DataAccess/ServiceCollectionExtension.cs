using EnglishVkBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishVkBot.DataAccess
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContext(this IServiceCollection serviceCollection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            //serviceCollection.AddTransient<IDataContext, DataContext>(provider => new DataContext(optionsBuilder.UseDefaultPostgreSqlOptions()));
            //serviceCollection.AddTransient(provider => (DataContext)provider.GetService<IDataContext>());
        }
    }
}