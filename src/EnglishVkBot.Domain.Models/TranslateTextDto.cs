using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EnglishVkBot.Domain.Models
{
    public class TranslateTextDto
    {
        [JsonProperty]
        public string Text { get; set; }
        
        [JsonProperty]
        public int TextDirectionId { get; set; }
        
        [JsonProperty]
        public int TargetDirectionId { get; set; }
        
        [JsonProperty]
        public bool IsAutoTextRecognition { get; set; }
        
        
        public TranslateTextDto()
        {
        }

        public TranslateTextDto(string text, int targetDirectionId)
        {
            Text = text;
            TargetDirectionId = targetDirectionId;
            IsAutoTextRecognition = true;
        }
        
        public TranslateTextDto(string text, int textDirectionId, int targetDirectionId, bool isAutoTextRecognition = false)
        {
            Text = text;
            TextDirectionId = textDirectionId;
            TargetDirectionId = targetDirectionId;
            IsAutoTextRecognition = isAutoTextRecognition;
        }
    }
}