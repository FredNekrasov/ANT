namespace ANTWebAPI.BLL.Models;

/*
 * Catalog entity is used for storing catalog data.
 * Properties:
 *    Id - primary key
 *    Name - catalog name
 *    Articles - collection of articles belonging to this catalog
 * Catalog entity has one-to-many relationship with Article entity.
 * One catalog can have many articles.
 */
public class Catalog
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Article> Articles { get; set; } = null!;
}
