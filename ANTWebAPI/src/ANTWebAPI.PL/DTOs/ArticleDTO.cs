namespace ANTWebAPI.PL.DTOs;

public class ArticleDTO
{
    public long Id { get; init; }
    public CatalogDTO Catalog { get; init; } = null!;
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string DateOrBanner { get; init; } = string.Empty;
}
