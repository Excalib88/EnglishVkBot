using EnglishVkBot.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EnglishVkBot.DataAccess.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Rollback()
        {
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
