using Dapper;
using Dapper.Contrib.Extensions;
using Sparta.Entities;
using System.Data;

namespace Sparta.Patient.API.DataAccessLayers.Repositories
{
    public class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : EntityBase<TId>
    {
        protected readonly PatientDbContext context;
        protected readonly string schemaName;
        protected readonly string dbTableName;
        protected readonly string keyName;
        public RepositoryBase(PatientDbContext DbContext)
        {
            context = DbContext;
        }
        protected string dbTableNameWithSchema
        {
            get { return $"[{schemaName}].[{dbTableName}]"; }
        }
        public TId Add(TEntity item)
        {
            item.EntityId = (TId)Convert.ChangeType(context.connection.Insert(item), typeof(TId));
            return item.EntityId;
        }

        public TId Delete(TEntity item)
        {
            item.EntityId = (TId)Convert.ChangeType(context.connection.Delete(item), typeof(TId));
            return item.EntityId;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.connection.GetAll<TEntity>();
        }

        public TEntity GetByID(TId id)
        {
            return context.connection.Get<TEntity>(id);
        }

        public void Update(TEntity item)
        {
            context.connection.Update(item);
        }
        public virtual int DeleteById(int id)
        {
            var query = $"DELETE FROM Patients WHERE id=" + id;
          return  context.connection.Execute(query);
        }
    }
}
