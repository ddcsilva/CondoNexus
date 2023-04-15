using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Models;
using CondoNexus.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CondoNexus.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly CondoNexusContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected Repository(CondoNexusContext db)
    {
        _context = db;
        _dbSet = db.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity> ObterPorId(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<List<TEntity>> ObterTodos()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task Adicionar(TEntity entity)
    {
        _dbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task Atualizar(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChanges();
    }

    public virtual async Task Remover(Guid id)
    {
        _dbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
