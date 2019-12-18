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
            string text, bool isAutoTextRecognition)
        {   
            if (isAutoTextRecognition)
            {
                var detectedLanguage = await _translateSdk.DetectLanguage(text);

                var targetDirection = detectedLanguage == "ru" ? "en": "ru";

                return await _translateSdk.TranslateText(text, 
                    $"{detectedLanguage}-{targetDirection}");  
            }
            
            return await _translateSdk.TranslateText(text, 
                $"{"ru"}-{"en"}");  
        }

        public async Task<List<string>> GetLanguages()
        {
            return await _translateSdk.GetLanguages();
        }
        
    }
}