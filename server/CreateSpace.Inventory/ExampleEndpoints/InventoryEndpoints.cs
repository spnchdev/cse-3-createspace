using CreateSpace.Inventory.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CreateSpace.Inventory.ExampleEndpoints;

public static class InventoryEndpoints
{
    public static void MapInventoryEndpoints(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api/v1/studio-equipments").WithTags("Inventory");

        api.MapGet("/", ([FromQuery] int page = 1, [FromQuery] int limit = 20, [FromQuery] string? sort = null) =>
            {
                var data = new[] { new Equipment(Guid.NewGuid(), "Sony A7IV", "Camera", 20m, true) };
                var meta = new MetaData(page, limit, 1, 1);
            
                return Results.Ok(new PaginatedResponse<Equipment>(data, meta));
            })
            .Produces<PaginatedResponse<Equipment>>(200)
            .WithSummary("Отримати список обладнання");

        api.MapPost("/", (Equipment dto) => Results.Created($"/api/v1/studio-equipments/{dto.Id}", (object?)dto))
            .Produces<Equipment>(201)
            .ProducesProblem(400)
            .WithSummary("Створити нове обладнання");

        api.MapPut("/{id:guid}", (Guid id, Equipment dto) => Results.Ok((object?)dto))
            .Produces<Equipment>(200)
            .ProducesProblem(400)
            .ProducesProblem(404)
            .WithSummary("Повністю оновити дані обладнання");

        api.MapDelete("/{id:guid}", (Guid id) => Results.NoContent())
            .Produces(204)
            .ProducesProblem(404)
            .WithSummary("Видалити обладнання з бази");

        api.MapPost("/{id:guid}/disable", (Guid id) => Results.Ok(new MessageResponse("Equipment disabled temporarily")))
            .Produces<MessageResponse>(200)
            .ProducesProblem(404)
            .ProducesProblem(409)
            .WithSummary("Зробити екіп недоступним");
    }
}