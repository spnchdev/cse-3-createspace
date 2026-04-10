using CreateSpace.Notification;
using CreateSpace.Notification.Consumers;
using MassTransit;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, NotificationJsonContext.Default);
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<BookingConfirmedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureJsonSerializerOptions(options =>
        {
            options.TypeInfoResolverChain.Insert(0, NotificationJsonContext.Default);
            
            return options;
        });
        
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.Run();