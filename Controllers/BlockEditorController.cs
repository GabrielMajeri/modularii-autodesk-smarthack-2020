using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartCityPlanner.Data;
using SmartCityPlanner.Models;

namespace SmartCityPlanner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockEditorController : ControllerBase
    {
        private readonly ILogger<BlockEditorController> _logger;
        private readonly AppDbContext _context;

        public BlockEditorController(ILogger<BlockEditorController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Buildings")]
        public ActionResult<ICollection<Building>> GetBuildings([Required, FromQuery] int blockId)
        {
            var block = _context.BuildingBlocks.Find(blockId);
            if (block == null)
            {
                _logger.LogError("Invalid building block ID");
                return BadRequest();
            }
            _context.Entry(block).Collection(b => b.Buildings).Load();
            return Ok(block.Buildings);
        }

        [HttpGet("BuildingType")]
        public ActionResult<BuildingType> GetBuildingType([Required, FromQuery] long buildingId)
        {
            var building = _context.Buildings.Find(buildingId);
            if (building == null)
            {
                _logger.LogError("Invalid building ID");
                return BadRequest();
            }
            return Ok(building.BuildingType);
        }

        [HttpPut("Building")]
        public IActionResult PutBuilding([FromQuery] long buildingId, [FromBody] Rectangle vertices)
        {
            var building = _context.Buildings.Find(buildingId);
            if (building == null)
            {
                _logger.LogError("Invalid building ID");
                return BadRequest();
            }
            building.Vertices = vertices;
            _context.Update(building);
            _context.SaveChanges();
            return Ok();
        }
    }
}
