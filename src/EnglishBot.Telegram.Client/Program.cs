using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using MihaZupan;
using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace EnglishBot.Telegram.Client
{
    class Program
    {
        private static TelegramBotClient bot;

        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var socksProxy = new HttpToSocks5Proxy(configuration["Proxy:Server"], int.Parse(configuration["Proxy:Port"]));

            bot = new TelegramBotClient(configuration["TelegramApi:Token"], socksProxy);

            StartBot();

            Console.ReadLine();
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

            if (message?.Type == MessageType.Voice)
            {
                var text = "";

                text = text == null || text == "" ? "unrecognized" : text;

                await bot.SendTextMessageAsync(message.Chat.Id, text);
            }
        }
    }
}
