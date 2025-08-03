using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Application.UseCases.Queries;
using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.UseCases
{
    public class GetAllTasksHandler(ITodoTaskRepository repository) : IRequestHandler<GetAllTasksQuery, List<TodoTask>>
    {
        private readonly ITodoTaskRepository _repository = repository;
        public async Task<List<TodoTask>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
