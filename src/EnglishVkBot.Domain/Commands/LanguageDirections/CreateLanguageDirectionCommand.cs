namespace EnglishVkBot.Domain.Commands
{
    public class CreateLanguageDirectionCommand: LanguageDirectionCommand
    {
        public CreateLanguageDirectionCommand(string name, string direction)
        {
            Name = name;
            Direction = direction;
        }
    }
}