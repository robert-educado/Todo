using Task = Todo.Models.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var taskList = new List<Task>
{
    new (1, "Städa", false),
    new (2, "Plugga C#", false)
};

app.MapGet("/api/tasks", () =>
{
    var taskListDtos = taskList.Select(x => new TaskDto(
        Id: x.Id,
        Name: x.Name,
        Completed: x.Completed));

    return Results.Ok(taskListDtos);
});

app.MapPost("/api/tasks", (CreateTaskDto createTaskDto) =>
{
    var task = new Task(createTaskDto.Name);

    task.Id = taskList.Max(x => x.Id) + 1;

    taskList.Add(task);

    var taskDto = new TaskDto(task.Id, task.Name, task.Completed);

    return Results.Created("", taskDto);
});

app.Run();

record TaskDto(int? Id, string Name, bool Completed);

record CreateTaskDto(string Name);