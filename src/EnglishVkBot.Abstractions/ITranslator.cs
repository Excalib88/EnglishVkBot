using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishVkBot.Domain.Models;

namespace EnglishVkBot.Abstractions
{
    public interface ITranslator
    {
        Task<string> Translate(string text, bool isAutoTextRecognition);
        Task<List<string>> GetLanguages();
    }
}