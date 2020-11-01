using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCityPlanner.Data;
using SmartCityPlanner.Models;

namespace SmartCityPlanner.Pages
{
    public class BuildingBlockModel : PageModel
    {
        private readonly AppDbContext _context;

        public BuildingBlock BuildingBlock { get; set; }

        public BuildingBlockModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var block = await _context.BuildingBlocks.FindAsync(id);
            if (block == null)
            {
                return BadRequest();
            }
            BuildingBlock = block;
            return Page();
        }
    }
}
