using EnglishVkBot.Domain.Models;
using RestEase;
using System.Threading.Tasks;

namespace EnglishVkBot.Abstractions.Models
{
    public interface ITranslatorModel
    {
        [Post("Translator/Translate")]
        Task<string> Translate([Body] TranslateTextDto translateTextDto);
    }
}
