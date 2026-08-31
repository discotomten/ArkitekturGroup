using Features.Todos;
using Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITodoStore, TodoStore>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.CreateTodo();

app.Run();
