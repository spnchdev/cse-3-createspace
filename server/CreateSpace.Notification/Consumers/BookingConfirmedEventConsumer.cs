using CreateSpace.Contracts.Events;
using MassTransit;

namespace CreateSpace.Notification.Consumers;

public class BookingConfirmedEventConsumer : IConsumer<BookingConfirmedEvent>
{
    public Task Consume(ConsumeContext<BookingConfirmedEvent> context)
    {
        Console.WriteLine($"SMS sent via Twilio for booking {context.Message.BookingId}");
        
        return Task.CompletedTask;
    }
}