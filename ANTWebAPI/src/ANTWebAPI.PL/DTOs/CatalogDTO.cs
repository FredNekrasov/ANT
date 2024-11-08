namespace ANTWebAPI.PL.DTOs;

/*
 * Catalog DTO is used to transfer information about the catalog entity to the client
 */
public class CatalogDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
