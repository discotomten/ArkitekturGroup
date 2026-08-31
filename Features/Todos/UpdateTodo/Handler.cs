using Infrastructure.Storage;
using Microsoft.Extensions.Logging;
using Shared;

namespace Features.Todos.UpdateTodo;

public sealed class Handler(
    ITodoStore store)
{
    public UpdateTodoResult Execute(
        int id,
        UpdateTodoRequest? request)
    {
        if (id <= 0)
        {
            return UpdateTodoResult.InvalidId;
        }

        if (request is null)
        {
            return UpdateTodoResult.EmptyRequest;
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            return UpdateTodoResult.InvalidDescription;
        }

        var dto = new TodoItemDto
        {
            Description = request.Description.Trim(),
            IsFinished = request.IsFinished
        };

        var updated = store.Update(dto, id);

        if (!updated)
        {
            return UpdateTodoResult.NotFound;
        }

        return UpdateTodoResult.Success;
    }
}

public enum UpdateTodoResult
{
    Success,
    InvalidId,
    EmptyRequest,
    InvalidDescription,
    NotFound
}