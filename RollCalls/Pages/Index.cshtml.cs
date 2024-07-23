using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RollCalls.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<SelectListItem> Camps { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Camps = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Asher" },
                new SelectListItem { Value = "1", Text = "Benji" },
                new SelectListItem { Value = "2", Text = "Gad" },
                new SelectListItem { Value = "3", Text = "Izzy" },
                new SelectListItem { Value = "4", Text = "Judah" },
                new SelectListItem { Value = "5", Text = "Levi" },
                new SelectListItem { Value = "6", Text = "Naph" },
                new SelectListItem { Value = "7", Text = "Reuben" },
                new SelectListItem { Value = "8", Text = "Simeon" },
                new SelectListItem { Value = "9", Text = "Zeb" }
            };
        }

        public void OnGet()
        {

        }
    }
}
