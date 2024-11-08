using ANTWebAPI.BLL.Models;

namespace ANTWebAPI.BLL.Utils;

public static class VerifyExtensions //Only extenstion functions that check the data
{
    //simplification of conditions
    /*
     * IsBlank - check if string is null or empty or white space only
     * @param string str - string to check for blank
     * @return bool - true if string is null or empty or white space only false otherwise
     */
    private static bool IsBlank(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    /*
     * IsNegative - check if long is negative
     * @param long l - long to check for negative
     * @return bool - true if long is negative false otherwise
     */
    private static bool IsNegative(this long l) => l < 0;

    //Validate data
    /*
     * IsDataValid is extension method to check if data is valid or not 
     * @param Catalog catalog - catalog to check for validity
     * @return bool - true if data is valid false otherwise
     */
    public static bool IsDataValid(this Catalog catalog) => !(catalog.Id.IsNegative() || catalog.Name.IsBlank());
    /*
     * IsDataValid is extension method to check if data is valid or not
     * @param Article article - article to check for validity
     * @return bool - true if data is valid false otherwise
     */
    public static bool IsDataValid(this Article article) => !(article.Id.IsNegative() || article.Title.IsBlank() || article.CatalogId.IsNegative());
    /*
     * IsDataValid is extension method to check if data is valid or not 
     * @param Content content - content to check for validity
     * @return bool - true if data is valid false otherwise
     */
    public static bool IsDataValid(this Content content) => !(content.Id.IsNegative() || content.Data.IsBlank() || content.ArticleId.IsNegative());
}
