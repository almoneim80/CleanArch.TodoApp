using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Application.UseCases.Queries;
using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.UseCases
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TodoTask?>
    {
        private readonly ITodoTaskRepository _repository;

        public GetTaskByIdHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
