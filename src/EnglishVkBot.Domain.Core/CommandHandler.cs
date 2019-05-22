using System.Linq;
using AutoMapper;
using EnglishVkBot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishVkBot.Domain.Core
{
    public abstract class CommandHandler<TEntity, TCommand>
        where TEntity : Entity
        where TCommand : Command
    {
        protected readonly IMapper Mapper;
        protected readonly DbSet<TEntity> DbSet;
        private readonly IDataContext dataContext;

        protected CommandHandler(IDataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            Mapper = mapper;
            DbSet = dataContext.DbSet<TEntity>();
        }

        protected bool Commit()
        {
            return dataContext.SaveChanges() > 0;
        }

        protected int Create(TCommand command)
        {
            var entity = Mapper.Map<TEntity>(command);
            DbSet.Add(entity);
            if (Commit())
                return entity.Id;
            return -1;
        }

        protected void Update(TCommand command)
        {
            DbSet.Update(Mapper.Map<TEntity>(command));
            Commit();
        }

        protected void Delete(TCommand command)
        {
            var deleteGroup = DbSet.Single(c => c.Id == command.Id);
            DbSet.Remove(deleteGroup);
            Commit();
        }
    }
}