using System.Collections.Generic;
using EnglishVkBot.Domain.Core;
using EnglishVkBot.Domain.Models;

namespace EnglishVkBot.Domain.Commands
{
    public abstract class TranslateTextCommand: Command
    {
        public string Text { get; protected set; }
        public int TextDirectionId { get; protected set; }
        public int TargetDirectionId { get; protected set; }
        public bool IsAutoTextRecognition { get; protected set; }
    }
}