using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RollCalls.Entity;

namespace RollCalls.Pages
{
    public class EditModel : PageModel
    {
        private readonly RollCallContext _context;

        public static List<SelectListItem> _lightings = new()
        {
            new SelectListItem { Value = "0", Text = "Standard lighting" },
            new SelectListItem { Value = "1", Text = "Center spotlight" },
            new SelectListItem { Value = "2", Text = "Camp color" },
            new SelectListItem { Value = "3", Text = "Party lights" },
            new SelectListItem { Value = "4", Text = "All on" },
        };

        public EditModel(RollCallContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string campId)
        {
            string camp = "";
            int id;
            RollCalls.Entity.Submission? temp = null;

            if (int.TryParse(campId, out id))
            {
                temp = _context.Submissions.FirstOrDefault(sub => sub.Id == id);
            }
            if (temp == null)
            {
                camp = IndexModel._camps.Single(camp => camp.Value == campId).Text;
                Submission = new Submission(id, camp);
                ViewData["Camp"] = camp;
            }
            else
            {
                ViewData["Camp"] = temp.Name;
                Submission = temp;
            }
                

            return Page();
        }

        [BindProperty]
        public Submission Submission { get; set; } = null!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Submission.Iteration++;
            if (Submission.Iteration == 1)
            {
                _context.Submissions.Add(Submission);
            }
            else
            {
                _context.Submissions.Update(Submission);
            }
            await _context.SaveChangesAsync();
            
            return RedirectToPage("/Success");
        }
    }
}
