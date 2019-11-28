using AutoMapper;
using EnglishVkBot.Domain.Commands;
using EnglishVkBot.Domain.Models;

namespace EnglishVkBot.Domain.Mappings
{
    public class TranslateTextProfile: Profile
    {
        public TranslateTextProfile()
        {
            CreateMap<CreateTranslateTextCommand, TranslateTextDto>().ForMember(
                x => x.TargetDirection, opt => opt.Ignore());
            
            CreateMap<CreateTranslateTextCommand, TranslateTextDto>().ForMember(
                x => x.TextDirection, opt => opt.Ignore());
        }
        
    }
}