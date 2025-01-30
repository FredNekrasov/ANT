using System.ComponentModel.DataAnnotations.Schema;

namespace ANTWebAPI.BLL.Models;

/*
 * Content entity is used for storing content data.
 * Properties:
 *    Id - primary key for content
 *    ArticleId - foreign key for article
 *    Data - content data for the article (contacts, images etc.)
 *    Article is the navigation property for the article entity to which this content belongs
 * Content entity has one-to-many relationship with Article entity. Many contents can belong to one article
 */
public class Content
{
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public string Data { get; set; } = string.Empty;//it can be contacts or images
    [ForeignKey(nameof(ArticleId))]
    public Article Article { get; init; } = null!;
}
