using MegaFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Data.Daos;

public class Dao<TEntity> : IDao<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _entities;

    public Dao(AppDbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<TEntity> GetAll() => _entities.ToList();

    public TEntity? GetById(int id)
    {
        var entity = _entities.Find(id);
        if (entity != null) _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
        _context.SaveChanges();
    }
}
