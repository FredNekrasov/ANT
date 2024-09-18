namespace ANTWebAPI.BLL.Models;

public class Catalog
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Article> Articles { get; set; } = null!;
}
