using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.UseCases.Queries
{
    public record GetTaskByIdQuery(Guid Id) : IRequest<TodoTask?>;
}
