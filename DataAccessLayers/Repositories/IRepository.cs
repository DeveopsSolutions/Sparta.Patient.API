using System.Linq.Expressions;

namespace Sparta.Patient.API.DataAccessLayers.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(TId id);
        TId Add(TEntity item);
        void Update(TEntity item);
        TId Delete(TEntity item);
    }
}

