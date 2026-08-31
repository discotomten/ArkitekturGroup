using Domain;
using Shared;

namespace Infrastructure.Storage;

public record TodoStats(int CreatedCount, int CompletedCount, int DeletedCount);

public interface ITodoStore
{
    public IReadOnlyCollection<TodoItem> GetAll();

    public TodoItem? GetById(int id);

    public TodoItem Add(string description);

    public bool Update(TodoItemDto todoItem, int id);
    public bool Remove(int id);
    public TodoStats GetStatistics();
}