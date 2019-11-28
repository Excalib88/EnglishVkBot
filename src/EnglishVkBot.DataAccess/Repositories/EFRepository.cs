using EnglishVkBot.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnglishVkBot.DataAccess.Repositories
{
    public class EFRepository : IDbRepository
    {
        private readonly DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<IEntity> Get(Expression<Func<IEntity, bool>> selector)
        {
            return _context.Set<IEntity>().Where(selector).AsQueryable();
        }

        public async Task Add(IEntity newEntity)
        {
            await _context.Set<IEntity>().AddAsync(newEntity);
        }

        public async Task Add(IEnumerable<IEntity> newEntities)
        {
            await _context.Set<IEntity>().AddRangeAsync(newEntities);
        }

        public async Task Remove(IEntity entity)
        {
            await Task.Run(() => _context.Set<IEntity>().Remove(entity));
        }

        public async Task Remove(IEnumerable<IEntity> entities)
        {
            await Task.Run(() => _context.Set<IEntity>().RemoveRange(entities));
        }

        public async Task<IEntity> Update(IEntity entity)
        {
            var updatedEntity = await Task.Run(() => _context.Set<IEntity>().Update(entity));
            return updatedEntity.Entity;
        }

        public async Task Update(IEnumerable<IEntity> entities)
        {
            await Task.Run(() => _context.Set<IEntity>().UpdateRange(entities));
        }

        public IQueryable<IEntity> GetAll()
        {
            return _context.Set<IEntity>().AsQueryable();
        }
    }
}
