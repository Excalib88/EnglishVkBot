using System;
using System.Linq;
using System.Threading.Tasks;
using EnglishVkBot.Abstractions.Models;
using EnglishVkBot.DataAccess.Entities;
using EnglishVkBot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishVkBot.DataAccess
{
    public sealed class DataContext : DbContext
    {
        public DbSet<LanguageDirection> LanguageDirections { get; set; }
        public DbSet<TranslateText> TranslatedTexts { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options){}

        public DataContext(DbContextOptions<DataContext> options, IServiceProvider serviceProvider) : base(options)
        {}
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