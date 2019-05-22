using AutoMapper;
using EnglishVkBot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnglishVkBot.Domain.Core
{
    public abstract class QueryHandler<T> where T : Entity
    {
        protected readonly IMapper Mapper;
        protected readonly DbSet<T> DbSet;

        protected QueryHandler(IDataContext dataContext, IMapper mapper)
        {
            DbSet = dataContext.DbSet<T>();
            Mapper = mapper;
        }
    }
}