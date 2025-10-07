using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.UseCases.Commands.TaskCMD
{
    public record UpdateTodoTaskCommand(Guid Id, string Title, string Description, bool IsCompleted) : IRequest<TodoTask?>;
}
