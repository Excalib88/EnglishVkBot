using EnglishVkBot.Domain.Core;

namespace EnglishVkBot.Domain.Queries.LanguageDirections
{
    public class GetLanguageByIdQuery
    {
        public int Id { get; protected set; }

        public GetLanguageByIdQuery(int id)
        {
            Id = id;
        }
    }
}