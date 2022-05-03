namespace CaseStudy.Server.Repository
{
    /// <summary>
    /// Generic Interface for a data repository
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IRepository<TModel>
    {
        /// <summary>
        /// Updates a single model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<TModel?> UpdateAsync(TModel model);

        /// <summary>
        /// Deletes a single model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(long id);

        /// <summary>
        /// Gets a single model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel?> GetAsync(long id); //READ

        /// <summary>
        /// Gets all models
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetAllAsync(); //READ

        /// <summary>
        /// Creates a single model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<TModel> CreateAsync(TModel model);

        /// <summary>
        /// Creates a set of models
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task CreateManyAsync(List<TModel> models);
    }
}