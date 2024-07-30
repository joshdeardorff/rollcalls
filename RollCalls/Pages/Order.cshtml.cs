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
            _pairs = await _context.Submissions.Select(s => new CampPair ( s.Name, s.Position )).ToListAsync();
        }

        public IActionResult OnPostSetPostition(int index, int position)
        {
            var campPair = _pairs[index];
            var camp = _context.Submissions.Single(c => c.Name == campPair.Name);
            camp.Position = position;
            _context.SaveChanges();
            return new JsonResult(new { success = true, message = "Position updated successfully" });
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
    }
}
