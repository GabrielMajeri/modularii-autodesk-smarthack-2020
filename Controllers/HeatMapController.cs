using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartCityPlanner.Data;
using SmartCityPlanner.Models;

namespace SmartCityPlanner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeatMapController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HeatMapController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Temperature")]
        public ActionResult<TemperatureData[]> GetTemperature()
        {
            var temperatureData = _context.TemperatureData.ToArray();
            return Ok(temperatureData);
        }

        [HttpGet("Rainfall")]
        public ActionResult<TemperatureData[]> GetRainfall()
        {
            var rainfallData = _context.RainfallData.ToArray();
            return Ok(rainfallData);
        }
    }
}
