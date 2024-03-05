using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LemonDotNetCore.RealtimeChartAppUsingSignalR
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TeamDataModel> Teams { get; set; }
    }
}

[Table("Tbl_Team")]
public class TeamDataModel
{
    [Key]
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Score { get; set; }
}