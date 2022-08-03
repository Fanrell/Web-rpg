using Microsoft.EntityFrameworkCore;
using RPG.Context.Repositories.Interface;
using RPG.Models;

namespace RPG.Context.Repositories;

public abstract class Repository <T> : IRepository<T> where T: BaseEntity
{
    private readonly RpgDbContext _dbContext;
    private DbSet<T> _entities;

    public Repository(RpgDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public T Get(Guid id)
    {
        return _entities.SingleOrDefault(s => s.Id == id);
    }

    public void Insert(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException();
        _entities.Add(entity);
        _dbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException();
        _dbContext.SaveChangesAsync();
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);
        _dbContext.Remove(entity);
        _dbContext.SaveChangesAsync();
    }
}