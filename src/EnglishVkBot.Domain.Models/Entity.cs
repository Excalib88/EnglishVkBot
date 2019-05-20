using Newtonsoft.Json;

namespace EnglishVkBot.Domain.Models
{
    public abstract class Entity
    {
        [JsonProperty]
        public int Id { get; private set; }
    }
}