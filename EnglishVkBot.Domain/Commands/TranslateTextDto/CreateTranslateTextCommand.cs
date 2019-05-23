using System.Collections.Generic;
using EnglishVkBot.Domain.Models;

namespace EnglishVkBot.Domain.Commands
{
    public class CreateTranslateTextCommand: TranslateTextCommand
    {
        public CreateTranslateTextCommand(string text, int targetDirectionId)
        {
            Text = text;
            TargetDirectionId = targetDirectionId;
            IsAutoTextRecognition = true;
        }
        
        public CreateTranslateTextCommand(
            string text, int textDirectionId, int targetDirectionId, bool isAutoTextRecognition = false)
        {
            Text = text;
            TextDirectionId = textDirectionId;
            TargetDirectionId = targetDirectionId;
            IsAutoTextRecognition = isAutoTextRecognition;
        }
    }
}