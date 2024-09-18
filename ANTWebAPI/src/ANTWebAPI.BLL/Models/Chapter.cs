namespace ANTWebAPI.BLL.Models;

public class Chapter
{
    public long Id { get; set; }
    public Catalog Catalog { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateOrBanner { get; set; } = string.Empty;
    public List<string> Content { get; set; } = null!;
}
