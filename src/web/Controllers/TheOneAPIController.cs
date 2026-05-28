using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace web.Controllers
{
    [Route("api/theoneapi")]
    [ApiController]
    public class TheOneAPIController : ControllerBase
    {
        private TheOneAPIService _service;
        public TheOneAPIController(TheOneAPIService service)
        {
            _service = service;
        }

        [HttpGet("book")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _service.GetBooks());
        }
    }
}
