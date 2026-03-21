namespace CreateSpace.Scheduling.DTOs;

public record Booking(
    Guid Id,
    Guid StudioId,
    DateTime StartTime,
    DateTime EndTime,
    string Status);