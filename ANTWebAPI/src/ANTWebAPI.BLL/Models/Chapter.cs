namespace ANTWebAPI.BLL.Models;

/*
 * Chapter entity is used for storing full article data.
 * Properties:
 *    Id - primary key for chapter
 *    Catalog is the catalog entity to which this chapter belongs
 *    Title - article title
 *    Description - article description
 *    DateOrBanner - article date or banner
 *    Content - collection of contents belonging to this article
 */
public class Chapter
{
    public long Id { get; init; }
    public Catalog Catalog { get; init; } = null!;
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string DateOrBanner { get; init; } = string.Empty;
    public List<string> Content { get; init; } = null!;
}
