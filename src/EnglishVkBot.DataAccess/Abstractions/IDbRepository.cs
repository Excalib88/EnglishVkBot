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
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T: class, IEntity;
        IQueryable<T> Get<T>() where T: class, IEntity;
        IQueryable<T> GetAll<T>() where T : class, IEntity;

        Task<long?> Add<T>(T newEntity) where T: class, IEntity;
        Task AddRange<T>(IEnumerable<T> newEntities) where T: class, IEntity;

        Task Remove<T>(T entity) where T: class, IEntity;
        Task Remove<T>(IEnumerable<T> entities) where T: class, IEntity;

        Task Update<T>(T entity) where T: class, IEntity;
        Task Update<T>(IEnumerable<T> entities) where T: class, IEntity;

    }
}
