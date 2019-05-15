using System;
using System.Linq;
using EnglishVkBot.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        private readonly IVkApi _vkApi;
        private readonly ITranslator _textTranslator;
        private readonly IConfiguration _configuration;
        
        public CallbackController(ILogger<CallbackController> logger, IVkApi vkApi, ITranslator textTranslator, IConfiguration configuration)
        {
            _logger = logger;
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
                    {
                        _vkApi.Messages.Send(new MessagesSendParams
                        {
                            RandomId = new DateTime().Millisecond,
                            PeerId = msg.PeerId.Value,
                            Message = translatedText
                        });
                    }

                    break;
                }

                case "group_join":
                {
                    var userId = VkNet.Model.User.FromJson(new VkResponse(updates.Object)).Id;
                    var user = _vkApi.Users.Get(new[] {userId}).FirstOrDefault();
                    
                    _vkApi.Messages.Send(new MessagesSendParams
                    {
                        RandomId = new DateTime().Millisecond,
                        PeerId = userId,
                        Message = $"Салам бродяга {user.FirstName} {user.LastName}"
                    });
                    Console.WriteLine($"{user.Id}, {user.FirstName} {user.LastName}");
                    _logger.LogInformation($"{user.Id}, {user.FirstName} {user.LastName}");
                    
                    break;
                }
            }

            return Ok("ok");
        }
    }
}