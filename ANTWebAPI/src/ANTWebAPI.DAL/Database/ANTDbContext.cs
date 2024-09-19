using ANTWebAPI.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ANTWebAPI.DAL.Database;

public class ANTDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ANT;Integrated Security=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Content> Contents { get; set; }
}
