using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnglishVkBot.DataAccess
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbSet<T> DbSet<T>() where T : class;

        IQueryable<T> Query<T>() where T : class;
    }
}