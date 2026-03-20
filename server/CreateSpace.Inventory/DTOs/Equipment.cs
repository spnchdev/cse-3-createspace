namespace CreateSpace.Inventory.DTOs;

public record Equipment(
    Guid Id,
    string Name,
    string Category,
    decimal PricePerHour,
    bool IsAvailable);