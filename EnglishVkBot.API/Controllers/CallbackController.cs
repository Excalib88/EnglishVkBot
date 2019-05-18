using System;
using System.Linq;
using EnglishVkBot.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Keyboard;
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
        private MessageKeyboard _languagesKeyboard;
        private MessageKeyboard _mainKeyboard;
        
        public CallbackController(ILogger<CallbackController> logger, IVkApi vkApi, ITranslator textTranslator, IConfiguration configuration)
        {
            _logger = logger;
            _vkApi = vkApi;
            _textTranslator = textTranslator;
            _configuration = configuration;
            SetLanguagesKeyboard();
            SetMainKeyboard();
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
                            Message = translatedText,
                            Keyboard = _languagesKeyboard
                        });
                    }

                    break;
                }

                case "group_join":
                {
                    var userId = VkNet.Model.User.FromJson(new VkResponse(updates.Object)).Id;
                    var user = _vkApi.Users.Get(new[] {userId}).FirstOrDefault();
                    var keyboardBuilder = new KeyboardBuilder();
                    
                    _vkApi.Messages.Send(new MessagesSendParams
                    {
                        RandomId = new DateTime().Millisecond,
                        PeerId = userId,
                        Message = $"Привет {user.FirstName} {user.LastName}! Чтобы перевести текст необходимо написать " +
                                  $"'Перевод' или нажать соответствующую кнопку",
                        Keyboard = _mainKeyboard
                    });

                    break;
                }
            }

            return Ok("ok");
        }

        private void SetLanguagesKeyboard()
        {
            var keyboardBuilder = new KeyboardBuilder();

            keyboardBuilder.AddButton("Английский", "", KeyboardButtonColor.Positive);
            keyboardBuilder.AddButton("Русский", "", KeyboardButtonColor.Positive);
            keyboardBuilder.AddButton("Немецкий", "", KeyboardButtonColor.Positive);
            keyboardBuilder.AddButton("Французский", "", KeyboardButtonColor.Positive);
            keyboardBuilder.SetOneTime();
            
            _languagesKeyboard = keyboardBuilder.Build();
        }
        
        private void SetMainKeyboard()
        {
            var keyboardBuilder = new KeyboardBuilder();

            keyboardBuilder.AddButton("Перевод", "", KeyboardButtonColor.Positive);
            keyboardBuilder.SetOneTime();
            
            _mainKeyboard = keyboardBuilder.Build();
        }
    }
}