using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Application.UseCases.Commands.TaskCMD;
using CleanArch.TodoApp.Domain.Entities;
using MediatR;

namespace CleanArch.TodoApp.Application.Handlers.TaskHDL
{
    public class UpdateTodoTaskHandler : IRequestHandler<UpdateTodoTaskCommand, TodoTask?>
    {
        private readonly ITodoTaskRepository _repository;

        public UpdateTodoTaskHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask?> Handle(UpdateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null)
                return null;

            task.UpdateTitle(request.Title);
            task.UpdateDescription(request.Description);

            if (request.IsCompleted != task.IsCompleted)
                task.ToggleTaskCompleted();

            await _repository.UpdateAsync(task);
            return task;
        }
    }
}
