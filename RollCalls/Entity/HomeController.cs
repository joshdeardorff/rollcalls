using Microsoft.AspNetCore.Mvc;
using RollCalls.Pages;

namespace RollCalls.Entity
{
    public class HomeController : Controller
    {
        private readonly RollCallContext _context;

        private readonly List<CampPair> _pairs;
        public HomeController(RollCallContext context)
        {
            _context = context;
            _pairs = _context.Submissions.Select(s => new CampPair(s.Name, s.Position)).ToList();
        }

        [HttpPost]
        public ActionResult SetPosition(int index, int position)
        {
            var campPair = _pairs[index];
            var camp = _context.Submissions.Single(c => c.Name == campPair.Name);
            camp.Position = position;
            _context.SaveChanges();
            return new JsonResult(new { success = true, message = "Position updated successfully" });
        }
    }
}
