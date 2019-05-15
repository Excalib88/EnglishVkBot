using System.Collections.Generic;
using System.Linq;
using EnglishVkBot.Abstractions.Models;

namespace EnglishVkBot.Translator
{
    public class DirectionHelper
    {
        private readonly TranslatorContext _translatorContext;
        
        public DirectionHelper()
        {
            _translatorContext = new TranslatorContext();
        }
        
        public string GetDirection(string name)
        {
            var direction = _translatorContext.Directions.FirstOrDefault(data => data.Name == name);
            return direction != null ? direction.Language : "ru";
        }

        public void AddDirection(string name, string direction)
        {
            if (!_translatorContext.Directions.Any(_ => _.Name == name))
            {
                _translatorContext.Directions.Add(new Direction(name, direction));
            }

            _translatorContext.SaveChanges();
        }
        
    }
}