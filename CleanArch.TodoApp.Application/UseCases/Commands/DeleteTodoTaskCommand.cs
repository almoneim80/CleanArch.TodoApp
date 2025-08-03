using MediatR;

namespace CleanArch.TodoApp.Application.UseCases.Commands
{
    public record DeleteTodoTaskCommand(string Id) : IRequest<bool>;
}
