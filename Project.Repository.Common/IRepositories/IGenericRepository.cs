using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common.IRepositories
{
    public interface IGenericRepository
    {
        Task<Tentity> GetId<Tentity>(Guid id) where Tentity : class;
        Task<int> Insert<TEntity>(TEntity entity) where TEntity : class;
        Task<int> Update<TEntity>(TEntity entity) where TEntity : class;
        Task<int> Delete<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> Table<TEntity>() where TEntity : class;
        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class;
    }
}
