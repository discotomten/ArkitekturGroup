using Features.Todos;
using Features.Todos.GetTodo;
using Infrastructure.Storage;
using Infrastructure.Logging;
using Features.Todos.ListTodos;
using Features.Statistics;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITodoStore, TodoStore>();
builder.Services.AddSingleton<IActivityLogger, FileActivityLogger>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.CreateTodo();
app.GetTodo();
app.ListTodos();
app.MapGetStatistics();

app.Run();
