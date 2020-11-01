using System.ComponentModel.DataAnnotations;
using System.IO;
using Aspose.Words;
using Aspose.Words.Reporting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCityPlanner.Data;

namespace SmartCityPlanner.Pages
{
    public class DocumentGeneratorModel : PageModel
    {
        public readonly AppDbContext _context;

        public DocumentGeneratorModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet([Required, FromQuery] long buildingId)
        {
            var building = _context.Buildings.Find(buildingId);
            if (building == null)
            {
                return BadRequest();
            }

            var templateDoc = new Document("Model-Cerere.doc");
            var finalDoc = new
            {
                AuthorName = building.Owner,
                Area = building.ComputeArea(),
                Perimeter = building.ComputePerimeter(),
            };
            var engine = new ReportingEngine();

            engine.BuildReport(templateDoc, finalDoc, "finalDoc");

            var stream = new MemoryStream();
            templateDoc.Save(stream, SaveFormat.Pdf);

            return File(stream, "application/pdf");
        }
    }
}
