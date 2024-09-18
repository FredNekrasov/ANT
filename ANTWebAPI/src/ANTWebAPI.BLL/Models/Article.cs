using System.ComponentModel.DataAnnotations.Schema;

namespace ANTWebAPI.BLL.Models;

public class Article
{
    public long Id { get; set; }
    public long CatalogId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateOrBanner { get; set; } = string.Empty;
    [ForeignKey(nameof(CatalogId))]
    public virtual Catalog Catalog { get; set; } = null!;
    public virtual ICollection<Content> Contents { get; set; } = null!;
}
