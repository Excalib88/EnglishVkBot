using System.Linq;
using System.Threading.Tasks;
using EnglishVkBot.Domain;
using EnglishVkBot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishVkBot.DataAccess
{
    public sealed class DataContext : DbContext, IDataContext
    {
        public DbSet<LanguageDirection> LanguageDirections { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options){}

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}