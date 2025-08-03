using CleanArch.TodoApp.Domain.Entities;

namespace CleanArch.TodoApp.Application.Interfaces
{
    public interface ITodoTaskRepository
    {
        Task<TodoTask> AddAsync(TodoTask task);
        Task<TodoTask?> GetByIdAsync(string id);
        Task<List<TodoTask>> GetAllAsync();
        Task UpdateAsync(TodoTask task);
        Task DeleteAsync(string id);
    }
}
