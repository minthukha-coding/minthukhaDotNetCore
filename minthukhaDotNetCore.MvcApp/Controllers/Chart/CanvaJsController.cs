using minthukhaDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using static minthukhaDotNetCore.MvcApp.Models.StackedAreaChartModel;

namespace minthukhaDotNetCore.MvcApp.Controllers.Chart;

public class CanvaJsController : Controller
{
    public IActionResult PieChart()
    {
        return View();
    }
    public IActionResult FinalcialChart()
    {
        var model = new FinalcialChartModel()
        {
            Title = new List<string> { "Netflix Stock Price in 2016" },
            Subtitles = new List<string> { "Weekly Averages" },
        };
        return View(model);
    }
    public IActionResult StackedAreaCharts()
    {
        var model = new StackedAreaChartModel()
        {
            Title = new List<string> { "Cumulative App Downloads on iTunes and Play Store" },
            AxisXtitle = new List<string> { "Months After Launch" },
            IOSDataPoints = new List<DataPoints>
                {
                    new DataPoints { x = 1, y = 3000 },
                    new DataPoints { x = 2, y = 7000 },
                    new DataPoints { x = 3, y = 10000 },
                    new DataPoints { x = 4, y = 14000 },
                    new DataPoints { x = 5, y = 23000 },
                    new DataPoints { x = 6, y = 31000 },
                    new DataPoints { x = 7, y = 42000 },
                    new DataPoints { x = 8, y = 56000 },
                    new DataPoints { x = 9, y = 64000 },
                    new DataPoints { x = 10, y = 81000 },
                    new DataPoints { x = 11, y = 105000 }
                },
            AndroidDataPoint = new List<DataPoints>
                {
                new DataPoints { x = 4, y = 4000 },
                new DataPoints { x = 5, y = 6000 },
                new DataPoints { x = 6, y = 9000 },
                new DataPoints { x = 7, y = 14000 },
                new DataPoints { x = 8, y = 21000 },
                new DataPoints { x = 9, y = 31000 },
                new DataPoints { x = 10, y = 46000 },
                new DataPoints { x = 11, y = 61000 }
                }
        };

        return View(model);
    }
    public IActionResult SplineCharts()
    {
        return View();
    }
}
