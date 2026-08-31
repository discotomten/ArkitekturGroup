using Infrastructure.Storage;
using Microsoft.AspNetCore.Http.HttpResults;
using Infrastructure.Logging;

public static class EndPoint
{
    public static void RemoveTodo(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/todos/{id}", async (int id, ITodoStore store, IActivityLogger logger) =>
        {
            var todo = store.GetById(id);
            if (todo is null) return Results.NotFound();

            store.Remove(id);

            await logger.LogAsync($"Tog bort: {todo.Description} (Id: {todo.Id})");

            return Results.NoContent();
        });
    }
}