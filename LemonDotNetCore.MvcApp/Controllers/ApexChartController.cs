using LemonDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult MixedChart()
        {
            var model = new MixedChart()
            {
                Income_colum_data = new List<double> { 1.4, 2, 2.5, 1.5, 2.5, 2.8, 3.8, 4.6 },
                Cashflow_column_data = new List<double> { 1.4, 2, 2.5, 1.5, 2.5, 2.8, 3.8, 4.6 },
            };
            return View(model);
        }
    }
}