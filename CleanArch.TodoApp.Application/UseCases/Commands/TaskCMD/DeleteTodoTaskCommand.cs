using MediatR;

namespace CleanArch.TodoApp.Application.UseCases.Commands.TaskCMD
{
    public record DeleteTodoTaskCommand(Guid Id) : IRequest<bool>;
}
