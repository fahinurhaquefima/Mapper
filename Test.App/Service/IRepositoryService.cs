namespace Test.App.Service;

public interface IRepositoryService<TEntity, IModel> where TEntity : class, new()
    where IModel : class 
{
    Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken);
    Task<IModel> UpdateAsync(long id, IModel model, CancellationToken cancellationToken);
    Task<IModel> DeleteAsync(long id, CancellationToken cancellationToken);
    Task<IModel> GetByIdAsync(long id, CancellationToken cancellationToken);
}

