using EnglishVkBot.Abstractions;
using EnglishVkBot.Abstractions.Models;
using EnglishVkBot.Domain.Models;
using EnglishVkBot.Translator;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using MihaZupan;
using RestEase;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace EnglishBot.Telegram.Client
{
    class Program
    {
        private static TelegramBotClient bot;
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var socksProxy = new HttpToSocks5Proxy(_configuration["Proxy:Server"], int.Parse(_configuration["Proxy:Port"]));
            bot = new TelegramBotClient(_configuration["TelegramApi:Token"], socksProxy);

            //bot = new TelegramBotClient(_configuration["TelegramApi:Token"]);
            StartBot();

            Console.WriteLine("Telegram bot service started");

            //for deployment
            //Console.ReadKey();
            Thread.Sleep(Timeout.Infinite);
        }

        static void StartBot()
        {
            bot.OnUpdate += OnUpdate;
            bot.StartReceiving();
        }

        public static async void OnUpdate(object sender, UpdateEventArgs e)
        {
            if (e.Update == null) return;

            var message = e.Update.Message;

            if (message?.Type == MessageType.Text)
            {
                if(message?.Text == "/start")
                {
                    await bot.SendTextMessageAsync(message?.Chat.Id, "Введите текст на нужном языке");
                    return;
                }

                Console.WriteLine("Tranlsate request starting");
                var api = RestClient.For<ITranslatorModel>(_configuration["TranslatorApi:BaseUrl"]);

                Console.WriteLine(_configuration["TranslatorApi:BaseUrl"]);
                var result = await api.Translate(new TranslateTextDto
                {
                    IsAutoTextRecognition = true,
                    Text = message?.Text
                });

                await bot.SendTextMessageAsync(message.Chat.Id, result);
            }
        }
    }
}
