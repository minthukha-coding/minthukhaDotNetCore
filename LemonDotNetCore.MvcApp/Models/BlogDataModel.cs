using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LemonDotNetCore.MvcApp.Models
{
    [Table("Tbl_Blog")]
    public class BlogDataModel
    {
        [Key]
        public int Blog_Id { get; set; }
        public string? Blog_Title { get; set; }
        public string? Blog_Author { get; set; }
        public string? Blog_Content { get; set; }
    }

    #region ApexChart
    public class MixedChart
    {
        public List<double>? Income_colum_data { get; set; }
        public List<double>? Cashflow_column_data { get; set; }
        public List<int>? Xaxis_categories { get; set; }
        public List<int>? Revenue_line { get; set; }
    }
    #endregion


    #region ChartJS
    public class RadarChartModel
    {
        public List<string>? Labeldata { get; set; }
        public List<string>? DataSetName { get; set; }
        public List<int>? DataSetData1 { get; set; }
        public List<int>? DataSetData2 { get; set; }
    }
    #endregion


    #region CanvaJs
    public class FinalcialChartModel
    {
        public List<string>? Title { get; set; }
        public List<string>? Subtitles { get; set; }
    }
    public class StackedAreaChartModel
    {
        public List<string>? Title { get; set; }
        public List<string>? AxisXtitle { get; set; }
        #region datapoint
        public List<DataPoints>? IOSDataPoints { get; set; }
        public List<DataPoints>? AndroidDataPoint { get; set; }
        public class DataPoints
        {
            public int x { get; set; }
            public int y { get; set; }
        }
        #endregion
    }
    #endregion


    #region High chart
    public class AudioBoxplotChartModel
    {
        public List<string>? Title { get; set; }
        public List<string>? Subtitle { get; set; }
    } 
    public class BulletGraphChartModel
    {
        public List<string>? Title { get; set; }
    }
    #endregion
}