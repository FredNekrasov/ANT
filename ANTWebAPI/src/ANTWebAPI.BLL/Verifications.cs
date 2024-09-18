using ANTWebAPI.BLL.Models;

namespace ANTWebAPI.BLL;

public static class Verifications //Only extenstion functions that check the data
{
    //simplification of conditions
    private static bool IsBlank(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);

    private static bool IsNegative(this long l) => l < 0;

    //Validate data
    public static bool IsDataValid(this Catalog catalog) => !(catalog.Id.IsNegative() || catalog.Name.IsBlank());

    public static bool IsDataValid(this Article article) => !(article.Id.IsNegative() || article.Title.IsBlank() || article.Catalog.Id.IsNegative());

    public static bool IsDataValid(this Content content) => !(content.Id.IsNegative() || content.Data.IsBlank() || content.ArticleId.IsNegative());
}
