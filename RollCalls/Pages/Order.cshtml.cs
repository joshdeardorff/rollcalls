using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RollCalls.Entity;

namespace RollCalls.Pages
{
    public class OrderModel : PageModel
    {
        private readonly RollCalls.Entity.RollCallContext _context;

        public OrderModel(RollCalls.Entity.RollCallContext context)
        {
            _context = context;
        }

        public IList<CampPair> _pairs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var currentSubmissions = await _context.Submissions.Select(s => s.Id).ToListAsync();
            _pairs = _context.Submissions.Select(sub => new CampPair( sub.Name, sub.Position )).ToList();
            List<int> idsToAdd = [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ];

            foreach (var id in currentSubmissions)
                idsToAdd.Remove(id);

            foreach (var id in idsToAdd)
            {
                string name = IndexModel._camps.Single(camp => camp.Value == $"{id}").Text;
                _pairs.Add(new CampPair (name, id));
                _context.Submissions.Add(new Submission(id, name));
            }
            _context.SaveChanges();
        }

        public async Task<IActionResult> OnPostAsync(List<CampPair> pairs)
        {
            foreach (var pair in pairs)
            {
                var camp = await _context.Submissions.SingleAsync(c => c.Name == pair.Name);
                camp.Position = pair.Position;
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("/Success");
        }
    }

    public class CampPair
    {
        public string Name { get; set; } = default!;
        public int? Position { get; set; }

        public CampPair(string name, int? position)
        {
            Name = name;
            Position = position;
        }
        public CampPair()
        {
        }
    }
}
