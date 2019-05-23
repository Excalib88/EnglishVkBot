using System.Collections.Generic;
using RestSharp;

namespace EnglishVkBot.RestRequests
{
    public interface IRequest<T>
    {
        void Send(T data);
    }
}