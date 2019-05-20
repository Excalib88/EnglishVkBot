using AutoMapper;
using EnglishVkBot.Domain.Commands;
using EnglishVkBot.Domain.Core;
using EnglishVkBot.Domain.Models;
using Zarnitza.CQRS;

namespace EnglishVkBot.Domain.CommandHandlers
{
    public class LanguageDirectionCommandHandler : CommandHandler<LanguageDirection, LanguageDirectionCommand>, 
        ICommandHandler<CreateLanguageDirectionCommand, int>
    {
        public LanguageDirectionCommandHandler(IDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        public int Handle(CreateLanguageDirectionCommand command)
        {
            return Create(command);
        }
    }
}