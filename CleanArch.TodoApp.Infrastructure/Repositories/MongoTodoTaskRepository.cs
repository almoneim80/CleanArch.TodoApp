using CleanArch.TodoApp.Application.Interfaces;
using CleanArch.TodoApp.Domain.Entities;
using CleanArch.TodoApp.Infrastructure.Configurations;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CleanArch.TodoApp.Infrastructure.Repositories
{
    public class MongoTodoTaskRepository : ITodoTaskRepository
    {
        private readonly IMongoCollection<TodoTask> _collection;
        public MongoTodoTaskRepository(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TodoTask>(settings.CollectionName);
        }

        public async Task<TodoTask> AddAsync(TodoTask task)
        {
            await _collection.InsertOneAsync(task);
            return task;
        }

        public async Task<TodoTask?> GetByIdAsync(string id)
        {
            var filter = Builders<TodoTask>.Filter.Eq(t => t.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<TodoTask>> GetAllAsync()
        {
            var filter = Builders<TodoTask>.Filter.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task UpdateAsync(TodoTask task)
        {
            var filter = Builders<TodoTask>.Filter.Eq(t => t.Id, task.Id);
            await _collection.ReplaceOneAsync(filter, task);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<TodoTask>.Filter.Eq(t => t.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
