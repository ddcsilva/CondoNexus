﻿using CondoNexus.Business.Models;
using System.Linq.Expressions;

namespace CondoNexus.Business.Interfaces.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
{
    Task Adicionar(TEntity entity);
    Task<TEntity> ObterPorId(Guid id);
    Task<List<TEntity>> ObterTodos();
    Task Atualizar(TEntity entity);
    Task Remover(Guid id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}
