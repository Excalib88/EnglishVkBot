using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnglishVkBot.DataAccess.Abstractions
{
    public interface IDbRepository 
    {
        IQueryable<IEntity> Get(Expression<Func<IEntity, bool>> selector);

        Task Add(IEntity newEntity);
        Task Add(IEnumerable<IEntity> newEntities);

        Task Remove(IEntity entity);
        Task Remove(IEnumerable<IEntity> entities);

        Task<IEntity> Update(IEntity entity);
        Task Update(IEnumerable<IEntity> entities);

        IQueryable<IEntity> GetAll();
    }
}
