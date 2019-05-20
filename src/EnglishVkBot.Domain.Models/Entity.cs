using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace EnglishVkBot.Domain.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public abstract class Entity
    {
        [JsonProperty]
        public int Id { get; private set; }
    }
}