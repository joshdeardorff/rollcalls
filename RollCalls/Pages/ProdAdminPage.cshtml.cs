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

        public IList<Submission> Submissions { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var list = await _context.Submissions.ToListAsync();
            Submissions = list.OrderBy(l => l.Position).ToList();
        }
    }
}
