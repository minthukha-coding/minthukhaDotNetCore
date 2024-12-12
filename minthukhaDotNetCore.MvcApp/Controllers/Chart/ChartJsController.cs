using minthukhaDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace minthukhaDotNetCore.MvcApp.Controllers.Chart;

public class ChartJsController : Controller
{
    public IActionResult ColumnChart()
    {
        return View();
    }
    public IActionResult RadarChart()
    {
        var model = new RadarChartModel
        {
            Labeldata = new List<string> { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running" },
            DataSetName = new List<string> { "My First DataSet", "My Second DataSet" },
            DataSetData1 = new List<int> { 65, 59, 90, 81, 56, 55, 40 },
            DataSetData2 = new List<int> { 28, 48, 40, 19, 96, 27, 100 }
        };
        return View(model);
    }
    public IActionResult ScatterChart()
    {
        return View();
    }
    public IActionResult Linechart()
    {
        var model = new LineChartModel
        {
            Labeldata = new List<string> { "January", "February", "March", "April", "May", "June", "July" },
            DataSetName = new List<string> { "My First Dataset" },
            DataSetData = new List<int> { 65, 59, 80, 81, 56, 55, 85 },
        };
        return View(model);

    }
}