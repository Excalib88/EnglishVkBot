using EnglishVkBot.Domain.Core;

namespace EnglishVkBot.Domain.Commands
{
    public abstract class LanguageDirectionCommand: Command
    {
        public string Name { get; protected set; }
        public string Direction { get; protected set; }
    }
}