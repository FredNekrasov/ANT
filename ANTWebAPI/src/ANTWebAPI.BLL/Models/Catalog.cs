namespace ANTWebAPI.BLL.Models;

/*
 * Catalog entity is used for storing catalog data.
 * Properties:
 *    Id - catalog identifier, primary key
 *    Name - catalog name
 * Catalog entity has one-to-many relationship with Article entity.
 * Many articles can belong to one catalog.
 */
public class Catalog
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Article> Articles { get; init; } = null!;
}
