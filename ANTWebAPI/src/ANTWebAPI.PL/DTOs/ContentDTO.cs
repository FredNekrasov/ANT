namespace ANTWebAPI.PL.DTOs;

/*
 * Content DTO is used to transfer information about the content entity to the client
 */
public class ContentDTO
{
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public string Data { get; set; } = string.Empty;//it can be contacts or images
}
