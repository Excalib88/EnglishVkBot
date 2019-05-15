using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishVkBot.Abstractions.Models;
using YandexTranslateCSharpSdk;

namespace EnglishVkBot.Translator
{
    public class TextTranslator
    {
        private readonly YandexTranslateSdk _translateSdk;
        private readonly List<ValueTuple<User, string>> _translatedTexts;

        public TextTranslator(string apiKey)
        {
            _translateSdk = new YandexTranslateSdk {ApiKey = apiKey};
            _translatedTexts = new List<ValueTuple<User, string>>();
        }

        public async ValueTask<string> Translate(string text, string direction)
        {
            return await _translateSdk.TranslateText(text, direction);   
        }
        
    }
}