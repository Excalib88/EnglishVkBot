using System;
using System.Collections.Generic;
using EnglishVkBot.Domain.Models;
using RestSharp;

namespace EnglishVkBot.RestRequests
{
    public class TranslateRequest: IRequest<TranslateTextDto>
    {
        private readonly IRestClient _restClient;
        
        public TranslateRequest(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.BaseUrl = new Uri("https://localhost:44331/");
            //var request = new RestRequest("", Method.POST);
            //var response = RestClient.Execute<LanguageDirection>(request);
        }

        public void Send(TranslateTextDto translateTextDto)
        {
            var request = new RestRequest("api/Translator/Translate", Method.POST);
            var response = _restClient.Execute<TranslateTextDto>(request);
            var resultTranslateTextDto = response.Data;
        }
    }
}