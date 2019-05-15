using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishVkBot.Abstractions
{
    public interface ITranslator
    {
        ValueTask<string> Translate(string text, string direction);
        List<string> GetLanguages();
    }
}