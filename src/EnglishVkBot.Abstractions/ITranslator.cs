using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishVkBot.Domain.Models;

namespace EnglishVkBot.Abstractions
{
    public interface ITranslator
    {
        ValueTask<string> Translate(string text, string textDirection, string targetDirection, bool isAutoTextRecognition);
        List<string> GetLanguages();
    }
}