using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnglishVkBot.Abstractions;
using EnglishVkBot.Domain.Commands;
using EnglishVkBot.Domain.Models;
using EnglishVkBot.Domain.Queries.LanguageDirections;
using Microsoft.AspNetCore.Mvc;
using Zarnitza.CQRS;

namespace EnglishVkBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class TranslatorController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;
        private readonly ITranslator _translator;

        public TranslatorController(IQueryBus queryBus, ICommandBus commandBus, IMapper mapper, ITranslator translator)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
            _translator = translator;
        }

        /// <summary>
        /// GET: api/Translator/GetAllLanguages/
        /// </summary>
        [HttpGet]
        [Route("GetAllLanguages")]
        public async Task<ActionResult<IEnumerable<LanguageDirection>>> GetAllLanguages()
        {
            var languages = await _queryBus.Query<Task<IEnumerable<LanguageDirection>>>();

            return languages.ToArray();
        }

        /// <summary>
        /// GET: api/Translator/GetLanguageById/1
        /// </summary>
        [HttpGet]
        [Route("GetLanguageById/{directionId}")]
        public ActionResult<LanguageDirection> GetLanguageById(int directionId)
        {
            var direction = _queryBus.Query<GetLanguageByIdQuery, LanguageDirection>(
                new GetLanguageByIdQuery(directionId));
            return direction;
        }

        /// <summary>
        /// POST: api/Translator/AddLanguage
        /// </summary>
        /// <param name="languageDirection"></param>
        [Route("AddLanguage/")]
        [HttpPost]
        public ActionResult<int> AddLanguage(LanguageDirection languageDirection)
        {
            var languageDirectionId = _commandBus.Handle<CreateLanguageDirectionCommand, int>(
                _mapper.Map<CreateLanguageDirectionCommand>(languageDirection));
            return languageDirectionId;
        }

        /// <summary>
        /// POST: api/Translator/Translate
        /// </summary>
        /// <param name="translateTextDto"></param>
        [Route("Translate")]
        [HttpPost]
        public ActionResult<string> Translate([FromBody]TranslateTextDto translateTextDto)
        {
            var textDirection = GetLanguageById(translateTextDto.TextDirectionId).Value.Direction;
            var targetDirection = GetLanguageById(translateTextDto.TargetDirectionId).Value.Direction;
            
            _commandBus.Handle<CreateTranslateTextCommand, int>(
                _mapper.Map<CreateTranslateTextCommand>(translateTextDto));
            
            var translatedText = _translator.Translate(
                translateTextDto.Text, textDirection, targetDirection, translateTextDto.IsAutoTextRecognition).Result;
            return translatedText;
        }
    }
}