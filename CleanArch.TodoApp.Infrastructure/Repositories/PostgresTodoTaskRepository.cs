using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Domain.Entities;
using CleanArch.TodoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.TodoApp.Infrastructure.Repositories
{
    public class PostgresTodoTaskRepository(TodoDbContext context) : ITodoTaskRepository
    {
        private readonly TodoDbContext _context = context;

        public async Task<TodoTask> AddAsync(TodoTask task)
        {
            await _context.TodoTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteAsync(string id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if (task != null)
            {
                _context.TodoTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoTask>> GetAllAsync()
        {
            return await _context.TodoTasks.AsNoTracking().ToListAsync();
        }

        public async Task<TodoTask?> GetByIdAsync(string id)
        {
            return await _context.TodoTasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(TodoTask task)
        {
            _context.TodoTasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
