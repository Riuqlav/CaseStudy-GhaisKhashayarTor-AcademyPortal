using CaseStudy.Shared;

namespace CaseStudy.Server.Repository
{
    public abstract class AbstractInMemoryRepository<TModel> : IRepository<TModel> where TModel : DBModel
    {
        protected List<TModel> _inMemoryCollection { get; set; } = new List<TModel>();

        public virtual Task<TModel> CreateAsync(TModel model)
        {
            if (model.Id == 0)
            {
                model.Id = _inMemoryCollection.Any() ? _inMemoryCollection.Max(x => x.Id) + 1 : 1;
            }
            _inMemoryCollection.Add(model);
            return Task.FromResult(model);
        }

        public virtual Task CreateManyAsync(List<TModel> models)
        {
            foreach (var model in models)
            {
                CreateAsync(model);
            }
            return Task.CompletedTask;
        }

        public virtual Task<bool> DeleteAsync(long id)
        {
            var entityToRemove = _inMemoryCollection.FirstOrDefault(x => x.Id == id);

            if (entityToRemove is not null)
            {
                _inMemoryCollection.Remove(entityToRemove);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public virtual Task<IEnumerable<TModel>> GetAllAsync()
        {
            return Task.FromResult(_inMemoryCollection.AsEnumerable());
        }

        public virtual Task<TModel?> GetAsync(long id)
        {
            var entity = _inMemoryCollection.FirstOrDefault(b => b.Id == id);

            if (entity is not null)
            {
                return Task.FromResult<TModel?>(entity);
            }

            return Task.FromResult<TModel?>(null);
        }

        public virtual async Task<TModel?> UpdateAsync(TModel model)
        {
            if (await DeleteAsync(model.Id))
            {
                await CreateAsync(model);
                return model;
            }

            return default!;
        }
    }
}
