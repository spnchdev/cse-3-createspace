using System.Text.Json.Serialization;
using CreateSpace.Scheduling.DTOs;

namespace CreateSpace.Scheduling;

[JsonSerializable(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails))]
[JsonSerializable(typeof(Booking))]
[JsonSerializable(typeof(Booking[]))]
[JsonSerializable(typeof(MetaData))]
[JsonSerializable(typeof(PaginatedResponse<Booking>))]
[JsonSerializable(typeof(MessageResponse))]
internal partial class SchedulingJsonContext : JsonSerializerContext;