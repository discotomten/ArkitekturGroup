using Domain;
using Shared;

namespace Infrastructure.Storage;

public interface ITodoStore
{
    public IReadOnlyCollection<TodoItem> GetAll();

    public TodoItem? GetById(int id);

    public TodoItem Add(string description);


}