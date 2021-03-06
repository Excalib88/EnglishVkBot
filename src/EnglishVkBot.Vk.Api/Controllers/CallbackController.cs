using System;
using System.Linq;
using EnglishVkBot.Vk.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.Keyboard;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace EnglishVkBot.Vk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IVkApi _vkApi;
        //private readonly ITranslator _textTranslator;
        private readonly IConfiguration _configuration;
        
        public CallbackController(ILogger<CallbackController> logger, IVkApi vkApi, IConfiguration configuration)
        {
            _logger = logger;
            _vkApi = vkApi;
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
                    var count = 0;
                    var msg = Message.FromJson(new VkResponse(updates.Object));
                    //var translatedText = _textTranslator.Translate(msg.Text, "en").Result;
                    var translatedText = "";
                    var keyboardBuilder = new KeyboardBuilder();

                    //var languages = _textTranslator.GetLanguages();
                    
                    for (var k = 1; k < 5; k++)
                    {
                        for (var i = 1; i < 5; i++)
                        {
                            //keyboardBuilder.AddButton(languages[count], languages[count] + "extra", KeyboardButtonColor.Primary);
                            count++;
                        }
                        
                        keyboardBuilder.AddLine();
                    }
                    

                    keyboardBuilder.SetOneTime();
                    var keyboard = keyboardBuilder.Build();
                    
                    if (msg.PeerId != null)
                    {
                        _vkApi.Messages.Send(new MessagesSendParams
                        {
                            RandomId = new DateTime().Millisecond,
                            PeerId = msg.PeerId.Value,
                            Message = translatedText,
                            Keyboard = keyboard
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