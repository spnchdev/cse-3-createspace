namespace CreateSpace.Scheduling.DTOs;

public record PaginatedResponse<T>(
    IEnumerable<T> Data,
    MetaData Meta);