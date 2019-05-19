using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishVkBot.Abstractions.Models
{
    public class Direction
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Language { get; set; }

        public Direction(string name, string language)
        {
            Id = Guid.NewGuid();
            Name = name;
            Language = language;
        }
    }
}