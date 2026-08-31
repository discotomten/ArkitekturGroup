using Features.Todos;
using Features.Todos.GetTodo;
using Infrastructure.Storage;
using Infrastructure.Logging;
using Features.Todos.ListTodos;
using Features.Todos.UpdateTodo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITodoStore, TodoStore>();
builder.Services.AddSingleton<IActivityLogger, FileActivityLogger>();
builder.Services.AddScoped<Features.Todos.UpdateTodo.Handler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseDefaultFiles();
app.UseStaticFiles();

app.CreateTodo();
app.GetTodo();
app.ListTodos();
app.UpdateTodo();

app.RemoveTodo();
app.Run();
