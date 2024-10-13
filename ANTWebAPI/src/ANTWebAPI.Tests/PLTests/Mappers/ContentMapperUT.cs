using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;
using ANTWebAPI.PL.mappers;

namespace ANTWebAPI.Tests.PLTests.Mappers;

public class ContentMapperUT
{
    [Fact]
    public void MapToContent()
    {
        var contentDto = new ContentDTO() { Id = 1, ArticleId = 1, Data = "Content" };
        Assert.NotNull(contentDto.ToModel());
    }
    [Fact]
    public void MapToContentDTO()
    {
        var content = new Content() { Id = 1, ArticleId = 1, Data = "Content" };
        Assert.NotNull(content.ToDto());
    }
}
