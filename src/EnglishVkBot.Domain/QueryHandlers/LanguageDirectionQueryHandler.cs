using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using EnglishVkBot.Domain.Core;
using EnglishVkBot.Domain.Models;
using EnglishVkBot.Domain.Queries.LanguageDirections;
using Microsoft.EntityFrameworkCore;
using Zarnitza.CQRS;

namespace EnglishVkBot.Domain.QueryHandlers
{
    public class LanguageDirectionsQueryHandler : QueryHandler<LanguageDirection>,
        IQueryHandler<Task<IEnumerable<LanguageDirection>>>,
        IQueryHandler<GetLanguageByIdQuery, LanguageDirection>
    {
        public LanguageDirectionsQueryHandler(IDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        Task<IEnumerable<LanguageDirection>> IQueryHandler<Task<IEnumerable<LanguageDirection>>>.Ask()
        {
            return Task.FromResult<IEnumerable<LanguageDirection>>(DbSet.ToList());
        }


        public LanguageDirection Ask(GetLanguageByIdQuery spec)
        {
            var a = DbSet.FirstOrDefault(d => d.Id == spec.Id);
            return a;
        }
    }
}