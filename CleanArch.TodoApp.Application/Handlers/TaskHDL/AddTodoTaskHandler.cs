using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Application.UseCases.Commands.TaskCMD;
using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.Handlers.TaskHDL
{
    public class AddTodoTaskHandler : IRequestHandler<AddTodoTaskCommand, TodoTask>
    {
        private readonly ITodoTaskRepository _repository;
        public AddTodoTaskHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask> Handle(AddTodoTaskCommand request, CancellationToken cancellationToken)
        {
            // 1. إنشاء المهمة
            var task = new TodoTask(request.Title, request.Description);

            // 2. حفظ المهمة
            return await _repository.AddAsync(task);
        }
    }
}
