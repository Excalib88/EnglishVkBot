using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EnglishVkBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class TranslatorController : ControllerBase
    {
        /// <summary>
        /// POST: api/Translator/Translate
        /// </summary>
        /// <param name="text"></param>
        /// <param name="direction"></param>
        [Route("Translate")]
        [HttpPost]
        public IActionResult Translate([FromBody] string text, [FromBody] string direction)
        {
            return Ok("ok");
        }
        
        /// <summary>
        /// GET: api/Translator/GetLanguageById/1
        /// </summary>
        [Route("GetLanguageById/{directionId}")]
        [HttpGet]
        public IActionResult GetLanguageById(int directionId)
        {
            return Ok();
        }

        /// <summary>
        /// GET: api/Translator/GetLanguagesList/
        /// </summary>
        [HttpGet]
        [Route("GetLanguagesList")]
        public ActionResult<IEnumerable<dynamic>> GetLanguagesList()
        {
            var languages = new List<dynamic>();
            
            return languages;
        }
    }
}