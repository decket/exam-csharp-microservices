using ExamService.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamService.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
      
    }

    public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
  }
}