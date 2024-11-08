using ANTWebAPI.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ANTWebAPI.DAL.Database;

/*
 * ANTDbContext is a database context class that is used to access the ANT database.
 */
public class ANTDbContext : DbContext
{
    /*
     * OnConfiguring is used to configure the database context.
     * 
     * The connection string is used to connect to the ANT database.
     * The integrated security is used to authenticate the user.
     * The initial catalog is used to specify the database.
     */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ANT;Integrated Security=true;");
    }
    /*
     * OnModelCreating is used to configure the database model.
     * 
     * The Assembly.GetExecutingAssembly() method is used to get the assembly that contains the configurations.
     */
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
