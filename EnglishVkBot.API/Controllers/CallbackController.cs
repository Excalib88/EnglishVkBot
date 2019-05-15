using System;
using EnglishVkBot.Abstractions.Models;
using EnglishVkBot.Translator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace EnglishVkBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVkApi _vkApi;
        private readonly TextTranslator _textTranslator;
        
        public CallbackController(IVkApi vkApi, IConfiguration configuration)
        {
            _vkApi = vkApi;
            _configuration = configuration;
            _textTranslator = new TextTranslator(_configuration["Config:YandexAccessToken"]);
        }

        [HttpPost]
        public IActionResult Callback([FromBody] Updates updates)
        {
            switch (updates.Type)
            {
                case "confirmation":
                    return Ok(_configuration["Config:Confirmation"]);
                case "message_new":
                {
                    var msg = Message.FromJson(new VkResponse(updates.Object));
                    var translatedText = _textTranslator.Translate(msg.Text, "ru-en").Result;

                    if (msg.PeerId != null)
                        _vkApi.Messages.Send(new MessagesSendParams
                        {
                            RandomId = new DateTime().Millisecond,
                            PeerId = msg.PeerId.Value,
                            Message = translatedText
                        });

                    break;
                }
            }

            return Ok("ok");
        }
    }
}