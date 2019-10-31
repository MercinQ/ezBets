using System.Collections.Generic;

namespace WebAPI.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
    }
}
