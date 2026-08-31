using Infrastructure.Storage;
using Microsoft.AspNetCore.Http.HttpResults;

public static class EndPoint
{
    public static void RemoveTodo(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/todos/{id}", (DeleteTodoRequest request, ITodoStore store) =>
        {
            var todo = store.GetById(request.id);
            if (todo is null) return Results.NotFound();

            store.Remove(request.id);
            return Results.NoContent();
        });
    }
}