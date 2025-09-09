using CleanArch.TodoApp.Api.Enums;
using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Application.UseCases.Commands;
using CleanArch.TodoApp.Infrastructure.Configurations;
using CleanArch.TodoApp.Infrastructure.Data;
using CleanArch.TodoApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddTodoTaskCommand).Assembly));

// MongoDb settings
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));


// Read repository type
var repoType = Enum.Parse<RepositoryType>(builder.Configuration["RepositoryType"] ?? "InMemory");

if(repoType  == RepositoryType.Mongo)
{
    builder.Services.AddSingleton<ITodoTaskRepository>(sp =>
    {
        var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        return new MongoTodoTaskRepository(settings);
    });
}
else if (repoType == RepositoryType.Postgres)
{
    builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

    builder.Services.AddScoped<ITodoTaskRepository, PostgresTodoTaskRepository>();
}
else
{
    //builder.Services.AddSingleton<ITodoTaskRepository, InMemoryTodoTaskRepository>();
}

Console.WriteLine($"[DEBUG] Repository type from config: {repoType}");

// Register Repository
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
