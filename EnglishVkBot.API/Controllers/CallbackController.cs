using System;
using EnglishVkBot.Abstractions;
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
        private readonly IVkApi _vkApi;
        private readonly ITranslator _textTranslator;
        private readonly IConfiguration _configuration;
        
        public CallbackController(IVkApi vkApi, ITranslator textTranslator, IConfiguration configuration)
        {
            _vkApi = vkApi;
            _textTranslator = textTranslator;
            _configuration = configuration;
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
                    var translatedText = _textTranslator.Translate(msg.Text, "en").Result;

                    if (msg.PeerId != null)
                        _vkApi.Messages.Send(new MessagesSendParams
                        {
                            RandomId = new DateTime().Millisecond,
                            PeerId = msg.PeerId.Value,
                            Message = translatedText
                        });

                    break;
                }

                case "group_join":
                {
                    var user = UserOrGroup.FromJson(new VkResponse(updates.Object));
                    
                    _vkApi.Messages.Send(new MessagesSendParams
                    {
                        RandomId = new DateTime().Millisecond,
                        PeerId = user.Users[0].Id,
                        Message = $"Салам бродяга {user.Users[0].FirstName}"
                    });
                    break;
                }
            }

            return Ok("ok");
        }
    }
}