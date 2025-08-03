//using CleanArch.TodoApp.Application.Interfaces;
//using CleanArch.TodoApp.Domain.Entities;

//namespace CleanArch.TodoApp.Infrastructure.Repositories
//{
//    public class InMemoryTodoTaskRepository : ITodoTaskRepository
//    {
//        private readonly List<TodoTask> _tasks = new();
//        private int _nextId = 1;

//        public Task<TodoTask> AddAsync(TodoTask task)
//        {
//            task.GetType().GetProperty("Id")?.SetValue(task, _nextId++);
//            _tasks.Add(task);
//            return Task.FromResult(task);
//        }

//        public Task<TodoTask?> GetByIdAsync(int id)
//        {
//            //var task = _tasks.FirstOrDefault(t => t.Id == id);
//            //return Task.FromResult(task);

//            return null; // temp
//        }

//        public Task<List<TodoTask>> GetAllAsync()
//        {
//            return Task.FromResult(_tasks.ToList());
//        }

//        public Task UpdateAsync(TodoTask task)
//        {
//            var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
//            if (existing != null)
//            {
//                _tasks.Remove(existing);
//                _tasks.Add(task);
//            }
//            return Task.CompletedTask;
//        }

//        public Task DeleteAsync(int id)
//        {
//            //var task = _tasks.FirstOrDefault(t => t.Id == id);
//            //if (task != null)
//            //    _tasks.Remove(task);
//            return Task.CompletedTask;
//        }
//    }
//}
