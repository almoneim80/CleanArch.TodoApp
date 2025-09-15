using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Domain.Entities;
using CleanArch.TodoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.TodoApp.Infrastructure.Repositories.TaskRepo
{
    public class PostgresTodoTaskRepository(TodoDbContext context) : ITodoTaskRepository
    {
        private readonly TodoDbContext _context = context;

        /// <inheritdoc/>
        public async Task<TodoTask> AddAsync(TodoTask task)
        {
            await _context.TodoTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if (task != null)
            {
                _context.TodoTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<List<TodoTask>> GetAllAsync()
        {
            return await _context.TodoTasks.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<TodoTask?> GetByIdAsync(Guid id)
        {
            return await _context.TodoTasks.AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(TodoTask task)
        {
            _context.TodoTasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
