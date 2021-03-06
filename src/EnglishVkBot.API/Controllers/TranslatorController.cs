using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishVkBot.Abstractions;
using EnglishVkBot.DataAccess.Abstractions;
using EnglishVkBot.DataAccess.Entities;
using EnglishVkBot.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishVkBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class TranslatorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITranslator _translator;
        private readonly IDbRepository _dbRepository;

        public TranslatorController(IMapper mapper, ITranslator translator, IDbRepository dbRepository)
        {
            _mapper = mapper;
            _translator = translator;
            _dbRepository = dbRepository;
        }

        /// <summary>
        /// GET: api/Translator/GetAllLanguages/
        /// </summary>
        [HttpGet]
        [Route("GetAllLanguages")]
        public async Task<ActionResult<IEnumerable<LanguageDirection>>> GetAllLanguages()
        {
            //var languages = ;await _queryBus.Query<Task<IEnumerable<LanguageDirection>>>();

            return new List<LanguageDirection>();
        }

        /// <summary>
        /// GET: api/Translator/GetLanguageById/1
        /// </summary>
        [HttpGet]
        [Route("GetLanguageById/{directionId}")]
        public async Task<ActionResult<LanguageDirection>> GetLanguageById(int directionId)
        {
            var tempDirection = new LanguageDirection { Id = 1, Direction = "ru" };
            var tempTargetDirection = new LanguageDirection { Id = 2, Direction = "en" };

            return directionId == 1 ? tempDirection : tempTargetDirection;
            //await _dbRepository.Get<LanguageDirection>().FirstOrDefaultAsync(x => x.Id == directionId);
        }

        /// <summary>
        /// POST: api/Translator/AddLanguage
        /// </summary>
        /// <param name="languageDirection"></param>
        [Route("AddLanguage/")]
        [HttpPost]
        public async Task<ActionResult<long?>> AddLanguage(LanguageDirection languageDirection)
        {
            return await _dbRepository.Add(languageDirection);
        }

        /// <summary>
        /// POST: api/Translator/Translate
        /// </summary>
        /// <param name="translateTextDto"></param>
        [Route("Translate")]
        [HttpPost]
        public async Task<ActionResult<string>> Translate([FromBody]TranslateTextDto translateTextDto)
        {
            return await _translator.Translate(
                translateTextDto.Text, 
                translateTextDto.IsAutoTextRecognition);
        }
    }
}