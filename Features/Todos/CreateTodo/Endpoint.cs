using Features.Todos.CreateTodo;
using Infrastructure.Storage;

namespace Features.Todos;

public static class Endpoint
{
    public static void CreateTodo(this IEndpointRouteBuilder app)
    {
        app.MapPost("/todos", (
            CreateTodoRequest request,
            ITodoStore store
        ) =>
        {
            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return Results.BadRequest("Beskrivning måste anges.");
            }

            var todo = store.Add(request.Description.Trim());

            return Results.Created($"/todos/{todo.Id}", todo);
        });
    }
}