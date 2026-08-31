using System.Reflection.Metadata.Ecma335;
using Domain;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Shared;

namespace Infrastructure.Storage;

public class TodoStore : ITodoStore
{
    private readonly List<TodoItem> _todos = [];
    private int _nextId = 1;
    private int _createdCount = 0;
    private int _completedCount = 0;
    private int _deletedCount = 0;
    public TodoStats GetStatistics() => new(_createdCount, _completedCount, _deletedCount);
    public TodoItem Add(string description)
    {
        var todoItem = new TodoItem
        {
            Id = _nextId,
            Description = description,
            IsFinished = false,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            ChangedAt = DateTime.UtcNow,
        };

        _todos.Add(todoItem);

        _nextId ++;

        _createdCount++;

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

    public bool Update(TodoItemDto todoItem, int id)
    {
        if (id <= 0)
        {
            var todoToAdd = new TodoItem
            {
                Id = _nextId,
                Description = todoItem.Description,
                IsFinished = todoItem.IsFinished,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                ChangedAt = DateTime.UtcNow,
            };

            _todos.Add(todoToAdd);

            _nextId++;
            _completedCount++;

            return true;
        }

        var todo = _todos.FirstOrDefault(x => x.Id == id);

        if (todo is null)
        {
            return false;
        }

        todo.Description = todoItem.Description;
        todo.IsFinished = todoItem.IsFinished;
        todo.ChangedAt = DateTime.UtcNow;

        return true; 
    }

    public bool Remove(int id)
    {
        if (id <= 0)
        {
            return false;
        }

        var todo = _todos.FirstOrDefault(x => x.Id == id);

        if (todo is null)
        {
            return false;
        }

        if (todo.IsDeleted is false)
        {
            todo.IsDeleted = true;
        }

        todo.ChangedAt = DateTime.UtcNow;

        _deletedCount++;
        //Vad underlättar för loggning och hämtning - att vi uppdaterar ChangedAt eller bara hanterar existerande todoItem?

        return true;
    }
}