using ANTWebAPI.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ANTWebAPI.DAL.Database;

public class ANTDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=ANT;");
    }
    // The `Assembly.GetExecutingAssembly()` method is used to get the assembly that contains entity configurations.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    // Catalogs, Articles and Contents are used to access the database tables.
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Content> Contents { get; set; }
}
