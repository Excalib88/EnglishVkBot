using System;
using EnglishVkBot.Domain.Models;
using RestSharp;

namespace EnglishVkBot.RestRequests
{
    public class RestApiService: IRestApiService
    {
        public RestClient RestClient { get; set; }

        public RestApiService()
        {
            RestClient = new RestClient("localhost");
        }
    }
}