using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Enums;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            string postalCodes = "";
            foreach(Cities city in Enum.GetValues<Cities>())
            {
                postalCodes += $"{city}: {(int)city}\n";
            }
            Console.WriteLine(postalCodes);
            return Ok(postalCodes);
        }
    }
}
