using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishVkBot.Abstractions;
using EnglishVkBot.Abstractions.Models;
using Microsoft.Extensions.Configuration;
using YandexTranslateCSharpSdk;

namespace EnglishVkBot.Translator
{
    public class TextTranslator: ITranslator
    {
        private readonly YandexTranslateSdk _translateSdk;
        private readonly List<ValueTuple<User, string>> _translatedTexts;
        private readonly IConfiguration _configuration;

        public TextTranslator(IConfiguration configuration)
        {
            _translateSdk = new YandexTranslateSdk
            {
                ApiKey = configuration["Config:YandexAccessToken"]
            };

            _translatedTexts = new List<ValueTuple<User, string>>();
        }

        public async Task<string> Translate(
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