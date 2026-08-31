using Infrastructure.Storage;

namespace Features.Todos.GetTodo;

public static class Endpoint
{
    public static void GetTodo(this IEndpointRouteBuilder app)
    {
        app.MapGet("/todos/{id}", (
            int id,
            ITodoStore store
        ) =>
        {
            if (id <= 0)
            {
                return Results.BadRequest("Id is not valid");
            }

            var todo = store.GetById(id);

            return Results.Ok(todo);
        });
    }
}
