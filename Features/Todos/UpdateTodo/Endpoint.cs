using Infrastructure.Storage;
using Shared;

namespace Features.Todos.UpdateTodo;

public static class Endpoint
{
    public static void UpdateTodo(this IEndpointRouteBuilder app)
    {
        app.MapPut("/todos/{id}", (
            int id,
            UpdateTodoRequest request,
            ITodoStore store
        ) =>
        {
            if (request is null)
            {
                return Results.BadRequest("Uppdaterad information måste anges.");
            }

            if (id <= 0)
            {
                return Results.NotFound();
            }

            var dto = new TodoItemDto
            {
                Description = request.Description,
                IsFinished = request.IsFinished
            };

            var result = store.Update(dto, id);

            return Results.Ok(result);
        });
    }
}