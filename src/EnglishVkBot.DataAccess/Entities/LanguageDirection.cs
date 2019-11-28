using EnglishVkBot.DataAccess.Abstractions;
using Newtonsoft.Json;

namespace EnglishVkBot.DataAccess.Entities
{
    public class LanguageDirection: EntityBase
    {
        [JsonProperty]
        public string Name { get; private set; }
        
        [JsonProperty]
        public string Direction { get; private set; }
        
        [JsonConstructor]
        public LanguageDirection()
        {
        }

        public LanguageDirection(string name, string direction)
        {
            Name = name;
            Direction = direction;
        }
    }
}