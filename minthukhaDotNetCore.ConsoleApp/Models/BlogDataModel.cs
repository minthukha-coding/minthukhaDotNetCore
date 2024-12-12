using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minthukhaDotNetCore.ConsoleApp.Models;

[Table("Tbl_blog")]
public class BlogDataModel
{
    [Key]
    public int Blog_Id { get; set; } 
    public string Blog_Title { get; set; } 
    public string Blog_Author { get; set; }
    public string Blog_Content { get; set; } 
}