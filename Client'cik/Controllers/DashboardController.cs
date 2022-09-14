using Microsoft.AspNetCore.Mvc;

namespace Client_cik.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
