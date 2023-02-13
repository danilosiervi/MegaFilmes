using MegaFilmes.Models;

namespace MegaFilmes.Data.Daos;

public interface IDao<TEntity> where TEntity : Entity
{
    void Add(TEntity entity);

    IEnumerable<TEntity> GetAll();

    TEntity? GetById(int id);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}
