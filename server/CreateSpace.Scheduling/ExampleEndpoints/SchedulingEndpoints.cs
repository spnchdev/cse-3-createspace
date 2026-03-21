using CreateSpace.Scheduling.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CreateSpace.Scheduling.ExampleEndpoints;

public static class SchedulingEndpoints
{
    public static void MapSchedulingEndpoints(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api/v1/bookings").WithTags("Scheduling");

        api.MapGet(
                "/",
                (
                    [FromQuery] Guid studioId,
                    [FromQuery] DateTime date,
                    [FromQuery] int page = 1,
                    [FromQuery] int limit = 20
                ) =>
                {
                    var data = new[]
                    {
                        new Booking(
                            Guid.NewGuid(),
                            studioId,
                            date.AddHours(10),
                            date.AddHours(12),
                            "Pending"
                        ),
                    };
                    var meta = new MetaData(page, limit, 1, 1);

                    return Results.Ok(new PaginatedResponse<Booking>(data, meta));
                }
            )
            .Produces<PaginatedResponse<Booking>>(200)
            .WithSummary("Отримати список бронювань студії на дату");

        api.MapPost(
                "/",
                (Booking dto) => Results.Created($"/api/v1/bookings/{dto.Id}", (object?)dto)
            )
            .Produces<Booking>(201)
            .ProducesProblem(400)
            .ProducesProblem(409)
            .WithSummary("Створити нове бронювання (зайняти слот)");

        api.MapDelete("/{id:guid}", (Guid id) => Results.NoContent())
            .Produces(204)
            .ProducesProblem(404)
            .WithSummary("Скасувати бронювання");

        api.MapPost(
                "/{id:guid}/confirm",
                (Guid id) =>
                    Results.Ok(
                        new MessageResponse("Booking confirmed and synced with Google Calendar")
                    )
            )
            .Produces<MessageResponse>(200)
            .ProducesProblem(404)
            .WithSummary("Підтвердити бронювання та засінкати з календарем (custom action)");
    }
}
