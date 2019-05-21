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
        IQueryHandler<IEnumerable<LanguageDirection>>
    {
        public LanguageDirectionsQueryHandler(IDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
        
        public async Task<LanguageDirection> Ask(GetLanguageByIdQuery spec)
        {
            return await DbSet.Where(d => d.Id == spec.Id).FirstOrDefaultAsync();
        }

        IEnumerable<LanguageDirection> IQueryHandler<IEnumerable<LanguageDirection>>.Ask()
        {
            return DbSet.ToList();
        }
    }
}