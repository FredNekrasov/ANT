namespace ANTWebAPI.PL.DTOs;

public class ContentDTO
{
    public long Id { get; init; }
    public long ArticleId { get; init; }
    public string Data { get; init; } = string.Empty;//it can be contacts or images
}
