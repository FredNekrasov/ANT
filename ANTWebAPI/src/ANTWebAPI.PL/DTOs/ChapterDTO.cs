namespace ANTWebAPI.PL.DTOs;

/*
 * Chapter DTO is used to transfer full information about the article to the client
 */
public class ChapterDTO
{
    public long Id { get; set; }
    public CatalogDTO Catalog { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateOrBanner { get; set; } = string.Empty;
    public List<string> Content { get; set; } = null!;
}
