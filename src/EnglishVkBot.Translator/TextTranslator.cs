using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishVkBot.Abstractions;
using EnglishVkBot.Abstractions.Models;
using EnglishVkBot.Domain.Models;
using YandexTranslateCSharpSdk;

namespace EnglishVkBot.Translator
{
    public class TextTranslator: ITranslator
    {
        private readonly YandexTranslateSdk _translateSdk;
        private readonly List<ValueTuple<User, string>> _translatedTexts;

        public TextTranslator(string apiKey)
        {
            _translateSdk = new YandexTranslateSdk {ApiKey = apiKey};
            _translatedTexts = new List<ValueTuple<User, string>>();
        }

        public async ValueTask<string> Translate(
            string text, string textDirection, string targetDirection, bool isAutoTextRecognition)
        {   
            if (isAutoTextRecognition)
            {
                var languageDetector = _translateSdk.DetectLanguage(text).Result;
                return await _translateSdk.TranslateText(text, 
                    $"{languageDetector}-{targetDirection}");  
            }
            
            return await _translateSdk.TranslateText(text, 
                $"{textDirection}-{targetDirection}");  
        }

        public List<string> GetLanguages()
        {
            return _translateSdk.GetLanguages().Result;
        }
        
    }
}