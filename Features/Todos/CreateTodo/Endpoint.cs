using Features.Todos.CreateTodo;
using Infrastructure.Logging;
using Infrastructure.Storage;

namespace Features.Todos;

public static class Endpoint
{
    public static void CreateTodo(this IEndpointRouteBuilder app)
    {
        app.MapPost("/todos", async (
            CreateTodoRequest request,
            ITodoStore store,
            IActivityLogger logger
        ) =>
        {
            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return Results.BadRequest("Beskrivning måste anges.");
            }

            var todo = store.Add(request.Description.Trim());

            await logger.LogAsync($"Skapade todo: {todo.Description} (Id: {todo.Id})");

            return Results.Created($"/todos/{todo.Id}", todo);
        });
    }
}