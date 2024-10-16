using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.mappers;

namespace ANTWebAPI.Tests.PLTests.Mappers;

public class ChapterMapperUT
{
    [Fact]
    public void MapToChapterDTO()
    {
        var chapter = new Chapter()
        {
            Id = 1,
            Catalog = new Catalog() { Id = 1, Name = "Catalog" },
            Title = "Title",
            Description = "Description",
            DateOrBanner = DateTime.Today.ToString(),
            Content = []
        };
        Assert.NotNull(chapter.ToDto());
    }
}
