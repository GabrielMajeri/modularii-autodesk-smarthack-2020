using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCityPlanner.Data;

namespace SmartCityPlanner.Pages
{
    public class BuildingPage : PageModel
    {
        private readonly AppDbContext _context;

        public string Urn { get; private set; }

        public BuildingPage(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long id)
        {
            var building = _context.Buildings.Find(id);
            if (building == null)
            {
                return BadRequest();
            }
            Urn = building.ModelUrn;
            return Page();
        }
    }
}
