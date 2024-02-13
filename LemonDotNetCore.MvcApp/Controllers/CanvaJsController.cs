using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.MvcApp.Controllers
{
	public class CanvaJsController : Controller
	{
		public IActionResult PieChart()
		{
			return View();
		}
		public IActionResult FinalcialChart()
		{
			return View();
		}
		public IActionResult SplineCharts()
		{
			return View();
		}
	}
}
