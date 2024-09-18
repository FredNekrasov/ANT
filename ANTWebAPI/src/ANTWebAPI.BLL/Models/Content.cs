using System.ComponentModel.DataAnnotations.Schema;

namespace ANTWebAPI.BLL.Models;

public class Content
{
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public string Data { get; set; } = string.Empty;//it can be contacts or images
    [ForeignKey(nameof(ArticleId))]
    public virtual Article Article { get; set; } = null!;
}
