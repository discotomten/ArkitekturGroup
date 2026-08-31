using Infrastructure.Storage;

namespace Features.Todos.ListTodos;

public static class Endpoint
{
    public static void ListTodos(this IEndpointRouteBuilder app)
    {
        app.MapGet("/todos", (
            ITodoStore store
        ) =>
        {
            var todos = store.GetAll();

            return Results.Ok(todos);
        });
    }
}