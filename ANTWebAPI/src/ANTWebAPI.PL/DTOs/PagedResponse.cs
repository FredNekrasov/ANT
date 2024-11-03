namespace ANTWebAPI.PL.DTOs;

public class PagedResponse<T>(int pageNumber, int pageSize, int totalRecords, ICollection<T> data)
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalRecords { get; set; } = totalRecords;
    public ICollection<T> Data { get; set; } = data;
}
