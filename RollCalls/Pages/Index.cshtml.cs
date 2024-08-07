using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RollCalls.Entity;

namespace RollCalls.Pages
{
    public class IndexModel : PageModel
    {
        private string Session { get; set; }
        public static List<SelectListItem> _camps => new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Asher" },
            new SelectListItem { Value = "2", Text = "Benji" },
            new SelectListItem { Value = "3", Text = "Gad" },
            new SelectListItem { Value = "4", Text = "Izzy" },
            new SelectListItem { Value = "5", Text = "Judah" },
            new SelectListItem { Value = "6", Text = "Levi" },
            new SelectListItem { Value = "7", Text = "Naph" },
            new SelectListItem { Value = "8", Text = "Reuben" },
            new SelectListItem { Value = "9", Text = "Simeon" },
            new SelectListItem { Value = "10", Text = "Zeb" }
        };

        public IndexModel()
        {
            Session = SetSession();
        }

        private string SetSession()
        {
            return Environment.GetEnvironmentVariable("Session") ?? "delta";
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAsync(string dropdownList, string passphrase)
        {
            string campId = dropdownList;
            if (!ValidatePassphrase(dropdownList, passphrase))
            {
                //ModelState.AddModelError("passphrase", "Incorrect passphrase");
                return RedirectToPage("/IncorrectPassword");
            }
            else
                return RedirectToPage("/Edit", new { campId });
        }

        private bool ValidatePassphrase(string campId, string passphrase)
        {
            string camp = _camps.Single(camp => camp.Value == campId).Text;

            return passphrase == (Session + camp).ToLower();
        }
    }
}
