using minthukhaDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace minthukhaDotNetCore.MvcApp.Controllers.Chart;

public class ApexChartController : Controller
{
    public IActionResult MixedChart()
    {
        var model = new MixedChart()
        {
            Income_colum_data = new List<double> { 1.4, 2, 2.5, 1.5, 2.5, 2.8, 3.8, 4.6 },
            Cashflow_column_data = new List<double> { 1.4, 2, 2.5, 1.5, 2.5, 2.8, 3.8, 4.6 },
            Xaxis_categories = new List<int> { 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016 },
            Revenue_line = new List<int> { 20, 29, 37, 36, 44, 45, 50, 58 },
        };
        return View(model);
    }
}