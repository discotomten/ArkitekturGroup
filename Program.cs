using Features.Todos;
using Features.Todos.GetTodo;
using Features.Todos.ListTodos;
using Features.Todos.UpdateTodo;
using Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITodoStore, TodoStore>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.CreateTodo();
app.GetTodo();
app.ListTodos();
app.UpdateTodo();

app.Run();
