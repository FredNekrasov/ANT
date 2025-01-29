using System.ComponentModel.DataAnnotations.Schema;

namespace ANTWebAPI.BLL.Models;

/*
 * Article entity is used for storing article data.
 * Properties:
 *    Id - primary key for article
 *    CatalogId - foreign key for catalog
 *    Title - article title
 *    Description - article description
 *    DateOrBanner - article date or banner
 *    Contents - collection of contents belonging to this article
 *    Catalog is the navigation property for the catalog entity to which this article belongs
 *    Contents is the navigation property of content collection associated with this article
 * Article entity has one-to-many relationship with Catalog and Content entities.
 * Many articles can belong to one catalog.
 * Many contents can belong to one article.
 */
public class Article
{
    public long Id { get; set; }
    public long CatalogId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateOrBanner { get; set; } = string.Empty;
    [ForeignKey(nameof(CatalogId))]
    public Catalog Catalog { get; init; } = null!;
    public ICollection<Content> Contents { get; init; } = null!;
}
