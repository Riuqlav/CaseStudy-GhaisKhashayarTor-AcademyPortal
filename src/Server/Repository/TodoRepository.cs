using CaseStudy.Shared;
using MongoDB.Driver;

namespace CaseStudy.Server.Repository
{
    public class TodoRepository : IRepository<Todo>
    {
        IMongoDatabase Database { get; set; }
        IMongoCollection<Todo> Todos { get; set; }

        public Task<Todo> CreateAsync(Todo model)
        {
            throw new NotImplementedException();
        }

        public Task CreateManyAsync(List<Todo> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var todos = await Todos.FindAsync(x => true);

            return todos.ToEnumerable();
        }

        public Task<Todo?> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Todo?> UpdateAsync(Todo model)
        {
            throw new NotImplementedException();
        }
    }
}
