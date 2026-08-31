using Domain;
using Microsoft.AspNetCore.Http.Features;
using Shared;

namespace Infrastructure.Storage;

public class TodoStore : ITodoStore
{
    private readonly List<TodoItem> _todos = [];
    private int _nextId = 1;

    public TodoItem Add(string description)
    {
        var todoItem = new TodoItem
        {
            Id = _nextId,
            Description = description,
            IsFinished = false,
            CreatedAt = DateTime.UtcNow,
            ChangedAt = DateTime.UtcNow,
        };

        _todos.Add(todoItem);

        _nextId ++;

        return todoItem;
    }

    public IReadOnlyCollection<TodoItem> GetAll()
    {
        return _todos.AsReadOnly();
    }

    public TodoItem? GetById(int id)
    {
        if (id <= 0)
        {
            throw new Exception("Id not valid");
        }

        return _todos.FirstOrDefault(x => x.Id == id);
    }
}