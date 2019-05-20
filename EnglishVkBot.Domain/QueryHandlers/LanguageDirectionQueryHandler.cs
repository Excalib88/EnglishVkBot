using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using EnglishVkBot.Domain.Core;
using EnglishVkBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Zarnitza.CQRS;

namespace EnglishVkBot.Domain.QueryHandlers
{
    public class LanguageDirectionsQueryHandler : QueryHandler<LanguageDirection>,
        IQueryHandler<IEnumerable<LanguageDirection>>,
        IQueryHandler<Task<IEnumerable<LanguageDirection>>>

    {
        public LanguageDirectionsQueryHandler(IDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        IEnumerable<LanguageDirection> IQueryHandler<IEnumerable<LanguageDirection>>.Ask()
        {
            return DbSet.Include(languageDirection => languageDirection.Direction).ToList();
        }

        async Task<IEnumerable<LanguageDirection>> IQueryHandler<Task<IEnumerable<LanguageDirection>>>.Ask()
        {
            return await DbSet.Include(languageDirection => languageDirection.Direction).ToListAsync();
        }
    }
}