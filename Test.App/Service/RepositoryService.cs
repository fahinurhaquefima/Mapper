
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.App.DatabaseContext;

namespace Test.App.Service;

public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel>
    where TEntity : class, new()
    where IModel : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dbContext;
    public RepositoryService(IMapper mapper, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        DbSet = _dbContext.Set<TEntity>();
    }
    public DbSet<TEntity> DbSet { get; }
    public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await DbSet.ToListAsync(cancellationToken);
        if (entities == null) return null;
        var data = _mapper.Map<IEnumerable<IModel>>(entities);
        return data;
    }
    public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<IModel, TEntity>(model);
        DbSet.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var insertedModel = _mapper.Map<TEntity, IModel>(entity);
        return insertedModel;
    }

    public async Task<IModel> UpdateAsync(long id, IModel model, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        _mapper.Map(model, entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        var updatedModel = _mapper.Map<TEntity, IModel>(entity);
        return updatedModel;
    }
    public async Task<IModel> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        DbSet.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var deletedModel = _mapper.Map<TEntity, IModel>(entity);
        return deletedModel;
    }

    public async Task<IModel> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        var model = _mapper.Map<TEntity, IModel>(entity);
        return model;
    }
}
