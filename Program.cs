using Features.Todos;
<<<<<<< Updated upstream
using Features.Todos.GetTodo;
=======
using Infrastructure.Logging;
>>>>>>> Stashed changes
using Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITodoStore, TodoStore>();
builder.Services.AddSingleton<IActivityLogger, FileActivityLogger>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.CreateTodo();
app.GetTodo();

app.Run();
