using Microsoft.AspNetCore.Mvc;
using RollCalls.Pages;

namespace RollCalls.Entity
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(IndexModel model)
        {
            return Ok(model);//come back to
        }
    }
}
