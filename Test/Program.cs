using System;
using System.Threading;
using EnglishVkBot.Abstractions.Models;
using EnglishVkBot.API;
using EnglishVkBot.Translator;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var direction = new DirectionHelper();
            var user = new User{Name = "Damir"};
            
            var textTranslator = new TextTranslator(
                "trnsl.1.1.20190514T085918Z.90452dc07df7151d.79577cba57e16bc77a5bfef43edb028c40bfba76");
            
            var translatedText = textTranslator.Translate("Hello brother", "de").Result;

            Console.WriteLine(translatedText);
        }
    }
}