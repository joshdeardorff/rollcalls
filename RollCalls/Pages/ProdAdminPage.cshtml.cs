using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RollCalls.Entity;

namespace RollCalls.Pages
{
    public class ProdAdminPageModel : PageModel
    {
        private readonly RollCallContext _context;

        public ProdAdminPageModel(RollCallContext context)
        {
            _context = context;
        }

        public IList<Submission> Submissions { get;set; } = new List<Submission>();

        public async Task OnGetAsync()
        {
            var list = await _context.Submissions.ToListAsync();
            Submissions = list.OrderBy(l => l.Position).ToList();
        }

        public IActionResult OnPostClearSubmissions()
        {
            var submissions = _context.Submissions.ToList();
            _context.Submissions.RemoveRange(submissions);
            _context.SaveChanges();

            foreach (var camp in IndexModel._camps)
            {
                int.TryParse(camp.Value, out var id);
                _context.Submissions.Add(new Submission(id, camp.Text));
            }

            return Page();
        }
    }
}
