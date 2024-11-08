namespace ANTWebAPI.PL.DTOs;

/*
 * Article DTO is used to transfer information about the article entity to the client
 */
public class ArticleDTO
{
    public long Id { get; set; }
    public CatalogDTO Catalog { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateOrBanner { get; set; } = string.Empty;
}
