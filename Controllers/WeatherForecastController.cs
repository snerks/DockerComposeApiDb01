using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerComposeApiDb01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockerComposeApiDb01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ColourContext colourContext
            )
        {
            _logger = logger;
            ColourContext = colourContext ?? throw new ArgumentNullException(nameof(colourContext));
        }

        public ColourContext ColourContext { get; }

        [HttpGet]
        public ActionResult<IEnumerable<Colour>> GetColourItems()
        {
            try
            {
                Console.WriteLine("GetColourItems:START");

                var results = ColourContext.ColourItems.ToList();

                Console.WriteLine("GetColourItems:END");

                return results;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("GetColourItems:Exception:START");

                Console.WriteLine(ex.ToString());

                Console.WriteLine("GetColourItems:Exception:END");

                throw;
            }
        }
    }
}
