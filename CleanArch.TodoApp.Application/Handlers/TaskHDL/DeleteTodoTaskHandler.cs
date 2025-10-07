﻿using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Application.UseCases.Commands.TaskCMD;
using MediatR;

namespace CleanArch.TodoApp.Application.Handlers.TaskHDL
{
    public class DeleteTodoTaskHandler : IRequestHandler<DeleteTodoTaskCommand, bool>
    {
        private readonly ITodoTaskRepository _repository;

        public DeleteTodoTaskHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null)
                return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
