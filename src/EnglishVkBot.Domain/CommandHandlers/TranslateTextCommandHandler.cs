using AutoMapper;
using EnglishVkBot.Domain.Commands;
using EnglishVkBot.Domain.Core;
using EnglishVkBot.Domain.Models;
using Zarnitza.CQRS;

namespace EnglishVkBot.Domain.CommandHandlers
{
    public class TranslateTextCommandHandler: CommandHandler<TranslateTextDto, TranslateTextCommand>,
        ICommandHandler<CreateTranslateTextCommand, int>
    {
        public TranslateTextCommandHandler(IDataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
        
        public int Handle(CreateTranslateTextCommand command)
        {
            return Create(command);
        }
    }
}