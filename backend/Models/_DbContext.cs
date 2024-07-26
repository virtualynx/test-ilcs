using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace TodoApi.Models;

public class _DbContext : DbContext
{
    public _DbContext(DbContextOptions<_DbContext> options): base(options)
    {
    }

    public DbSet<Simulation> Simulations { get; set; } = null!;
}