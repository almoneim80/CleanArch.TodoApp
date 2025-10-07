using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.UseCases.Commands.TaskCMD
{
    public record AddTodoTaskCommand(string Title, string Description) : IRequest<TodoTask>;
}
