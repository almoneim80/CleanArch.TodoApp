using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.UseCases.Commands
{
    public record UpdateTodoTaskCommand(string Id, string Title, string Description, bool IsCompleted) : IRequest<TodoTask?>;
}
