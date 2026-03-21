using System.Text.Json.Serialization;
using CreateSpace.Inventory.DTOs;

namespace CreateSpace.Inventory;

[JsonSerializable(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails))]
[JsonSerializable(typeof(Equipment))]
[JsonSerializable(typeof(Equipment[]))]
[JsonSerializable(typeof(MetaData))]
[JsonSerializable(typeof(PaginatedResponse<Equipment>))]
[JsonSerializable(typeof(MessageResponse))]
internal partial class InventoryJsonContext : JsonSerializerContext;