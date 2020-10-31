using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCityPlanner.Data;
using SmartCityPlanner.Models;

namespace SmartCityPlanner.Pages
{
    public class MapModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<BuildingBlock> BuildingBlocks { get; private set; }

        public MapModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            BuildingBlocks = _context.BuildingBlocks.ToList();
        }
    }
}
