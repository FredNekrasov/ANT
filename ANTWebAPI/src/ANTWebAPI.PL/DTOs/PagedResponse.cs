namespace ANTWebAPI.PL.DTOs;

/*
 * Paged Response DTO is used to send the paged response to the client
 */
public class PagedResponse<T>(int pageNumber, int pageSize, int totalRecords, ICollection<T> data)
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalRecords { get; set; } = totalRecords;
    public ICollection<T> Data { get; set; } = data;
}
