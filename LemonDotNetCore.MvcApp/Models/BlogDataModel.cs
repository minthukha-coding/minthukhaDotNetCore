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
    public class MixedChart
    {
        public List<double>? Income_colum_data { get; set; }
        public List<double>? Cashflow_column_data { get; set; }
        public List<int>? Xaxis_categories { get; set; }
        public List<int>? Revenue_line { get; set; }
    }
    public class RadarChartModel
    {
        public List<string>? Labeldata { get; set; }
        public List<string>? DataSetName { get; set; }
        public List<int>? DataSetData1 { get; set; }
        public List<int>? DataSetData2 { get; set; }
    }
}