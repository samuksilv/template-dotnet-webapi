using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace template.API.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase {

        private ILogger<TemplateController> _log;

        public TemplateController (ILogger<TemplateController> logger) {
            this._log = logger;
            this._log.LogInformation ("*** API funcionando ***");
        }

        [HttpGet("value")]        
        public async Task<ActionResult<IEnumerable<string>>> GetAsync () {
            return new string[] { "value1", "value2" };
        }

        [HttpGet ("value/{id}")]
        public async Task<ActionResult<string>> GetAsync (int id) {
            return "value";
        }

        [HttpPost ("value")]
        public async Task PostAsync ([FromBody] string value) { }

        [HttpPut ("value/{id}")]
        public async Task PutAsync ([FromRoute] int id, [FromBody] string value) { }

        [HttpDelete ("value/{id}")]
        public async Task DeleteAsync (int id) { }
    }
}