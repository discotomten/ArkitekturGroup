using Infrastructure.Storage;
using Shared;

namespace Features.Todos.UpdateTodo;

public static class Endpoint
{
    public static void UpdateTodo(this IEndpointRouteBuilder app)
    {
        app.MapPut("/todos/{id:int}", (
            int id,
            UpdateTodoRequest? request,
            Handler handler
        ) =>
        {

            var result = handler.Execute(id, request);

            return result switch
            {
                UpdateTodoResult.Success =>
                    Results.NoContent(),
                UpdateTodoResult.InvalidId =>
                    Results.BadRequest("Id måste vara större än 0."),
                UpdateTodoResult.EmptyRequest =>
                    Results.BadRequest("Uppdaterad information måste anges."),
                UpdateTodoResult.NotFound =>
                    Results.NotFound(),
                _ => Results.BadRequest()
            };
        });
    }
}