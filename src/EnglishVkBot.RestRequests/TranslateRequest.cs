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
            _restClient.BaseUrl = new Uri("http://localhost:5000/");
            //var request = new RestRequest("", Method.POST);
            //var response = RestClient.Execute<LanguageDirection>(request);
        }

        public void Send(TranslateTextDto translateTextDto)
        {
            var request = new RestRequest("api/Translator/Translate", Method.POST);
            request.AddHeader("content-type", "application/json-patch+json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(translateTextDto);
            
            var response = _restClient.Execute<TranslateTextDto>(request);
            
            Console.WriteLine(response.Content);
        }
    }
}