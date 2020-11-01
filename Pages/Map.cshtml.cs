using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCityPlanner.Data;
using SmartCityPlanner.Models;

namespace SmartCityPlanner.Pages
{
    public class MapModel : PageModel
    {
        private readonly AppDbContext _context;

        public ICollection<BuildingBlock> BuildingBlocks { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public MapModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var blocks = from b in _context.BuildingBlocks select b;
            if (SearchString != null)
            {
                blocks = blocks.Where(b => b.Name.ToLower().Contains(SearchString.ToLower()));
            }
            BuildingBlocks = blocks.ToArray();
        }
    }
}
