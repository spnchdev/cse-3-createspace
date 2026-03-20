namespace CreateSpace.Inventory.DTOs;

public record PaginatedResponse<T>(
    IEnumerable<T> Data,
    MetaData Meta);