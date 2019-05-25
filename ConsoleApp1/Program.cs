﻿using System;
using System.Collections.Generic;
using EnglishVkBot.Domain.Commands;
using EnglishVkBot.Domain.Models;
using EnglishVkBot.RestRequests;
using RestSharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = new TranslateRequest(new RestClient());
            
            request.Send(new TranslateTextDto("Привет", 1, 2, true));

            Console.ReadKey();
        }
    }
}