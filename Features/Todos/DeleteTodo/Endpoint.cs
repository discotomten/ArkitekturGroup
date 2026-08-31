using Infrastructure.Storage;
using Microsoft.AspNetCore.Http.HttpResults;

public static class EndPoint
{
    public static void RemoveTodo(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/todos/{id}", (int id, ITodoStore store) =>
        {
            var todo = store.GetById(id);
            if (todo is null) return Results.NotFound();


            return Results.NoContent();
        });
    }
}