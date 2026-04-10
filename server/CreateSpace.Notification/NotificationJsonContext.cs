using System.Text.Json.Serialization;
using CreateSpace.Contracts.Events;

namespace CreateSpace.Notification;

[JsonSerializable(typeof(BookingConfirmedEvent))]
internal partial class NotificationJsonContext : JsonSerializerContext
{
}