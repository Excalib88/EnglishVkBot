using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        IQueryHandler<GetLanguageByIdQuery, IEnumerable<LanguageDirection>>,
        IQueryHandler<GetLanguageByIdQuery, Task<IEnumerable<LanguageDirection>>>
    {
        public LanguageDirectionsQueryHandler(IDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        public async Task<IEnumerable<LanguageDirection>> Ask(GetLanguageByIdQuery spec)
        {
            return await DbSet.Include(languageDirection => languageDirection.Id == spec.Id).ToListAsync();
        }

        IEnumerable<LanguageDirection> IQueryHandler<GetLanguageByIdQuery, IEnumerable<LanguageDirection>>.Ask(
            GetLanguageByIdQuery spec)
        {
            return DbSet.Where(s => s.Id == spec.Id).ToList();
        }
    }
}