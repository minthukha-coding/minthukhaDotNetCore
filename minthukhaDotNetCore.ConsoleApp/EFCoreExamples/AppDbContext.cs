using minthukhaDotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace minthukhaDotNetCore.ConsoleApp.EFCoreExamples;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "LemonDotNetCore",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };

        optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<BlogDataModel> Blogs { get; set; }
}