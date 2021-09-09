using Microsoft.EntityFrameworkCore;

namespace CretaceousPark.Models
{
  public class CretaceousParkContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }

    public CretaceousParkContext(DbContextOptions<CretaceousParkContext> options)
      : base(options)
    {
    }
  }
}