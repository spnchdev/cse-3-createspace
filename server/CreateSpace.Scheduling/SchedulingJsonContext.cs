using System.Text.Json.Serialization;
using CreateSpace.Contracts.Events;
using CreateSpace.Scheduling.DTOs;

namespace CreateSpace.Scheduling;

[JsonSerializable(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails))]
[JsonSerializable(typeof(Booking))]
[JsonSerializable(typeof(Booking[]))]
[JsonSerializable(typeof(MetaData))]
[JsonSerializable(typeof(PaginatedResponse<Booking>))]
[JsonSerializable(typeof(MessageResponse))]
[JsonSerializable(typeof(BookingConfirmedEvent))]
[JsonSerializable(typeof(BookingConfirmedResponse))]
internal partial class SchedulingJsonContext : JsonSerializerContext;