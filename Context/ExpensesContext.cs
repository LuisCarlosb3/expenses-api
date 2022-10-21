using workspace.Models;
using Microsoft.EntityFrameworkCore;

namespace workspace.Context
{
  public class AppDbContext : DbContext
  {
    public DbSet<Expenses> Expenses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
  }
}