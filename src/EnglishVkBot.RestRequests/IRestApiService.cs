using RestSharp;

namespace EnglishVkBot.RestRequests
{
    public interface IRestApiService
    {
        RestClient RestClient { get; set; }
    }
}