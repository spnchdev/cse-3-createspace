namespace CreateSpace.Inventory.DTOs;

public record MetaData(
    int CurrentPage,
    int PageSize,
    int TotalItems,
    int TotalPages);