using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IQueryBus queryBus;
        private readonly ICommandBus commandBus;
        private readonly IMapper mapper;

        public TranslatorController(IQueryBus queryBus, ICommandBus commandBus, IMapper mapper)
        {
            this.queryBus = queryBus;
            this.commandBus = commandBus;
            this.mapper = mapper;
        }
        
        /// <summary>
        /// GET: api/Translator/GetLanguagesList/
        /// </summary>
        [HttpGet]
        [Route("GetLanguagesList")]
        public async Task<ActionResult<IEnumerable<LanguageDirection>>> GetLanguagesList()
        {
            var sessions = await queryBus.Query<Task<IEnumerable<LanguageDirection>>>();
            return sessions.ToArray();
        }
        
        /// <summary>
        /// GET: api/Translator/GetLanguageById/1
        /// </summary>
        [HttpGet]
        [Route("GetLanguageById/{directionId}")]
        public async Task<ActionResult<LanguageDirection>> GetLanguageById(int directionId)
        {
            var direction = await queryBus.Query<GetLanguageByIdQuery, Task<LanguageDirection>>(new GetLanguageByIdQuery(directionId));
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
            var languageDirectionId = commandBus.Handle<CreateLanguageDirectionCommand, int>(
                mapper.Map<CreateLanguageDirectionCommand>(languageDirection));
            return languageDirectionId;
        }
        
        /// <summary>
        /// POST: api/Translator/Translate
        /// </summary>
        /// <param name="text"></param>
        /// <param name="direction"></param>
        [Route("Translate")]
        [HttpPost]
        public IActionResult Translate([FromBody] string text, string direction)
        {
            return Ok("ok");
        }
    }
}