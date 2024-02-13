using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.MvcApp.Controllers
{
    public class HighChartController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
        public IActionResult AudioBoxplotChart()
        {
            return View();
        }
        public IActionResult BulletGraphChart()
        {
            return View();
        }
    }
}
