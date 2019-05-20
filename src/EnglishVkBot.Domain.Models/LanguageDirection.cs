using Newtonsoft.Json;

namespace EnglishVkBot.Domain.Models
{
    public class LanguageDirection: Entity
    {
        [JsonProperty]
        public string Name { get; private set; }
        
        [JsonProperty]
        public string Direction { get; private set; }
        
        [JsonConstructor]
        // Empty constructor for EF
        private LanguageDirection()
        {
        }

        public LanguageDirection(string name, string direction)
        {
            Name = name;
            Direction = direction;
        }
    }
}