using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Enums;

namespace web.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private PopulationCalculation _populationCalculationService;
        public CityController(PopulationCalculation populationCalculation)
        {
            _populationCalculationService = populationCalculation;
        }

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

        [HttpGet("{city}")]
        public ActionResult Get(Cities city)
        {
            return Ok(_populationCalculationService.EstimatedPopulation(city));
        }

        [HttpGet("city/{city}")]
        public ActionResult Get(Cities city, [FromHeader] int initialPopulation)
        {

            return Ok(_populationCalculationService.EstimatedPopulation(city, initialPopulation));
        }
    }
}
