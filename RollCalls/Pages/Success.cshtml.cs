using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RollCalls.Pages
{
    public class SuccessModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
