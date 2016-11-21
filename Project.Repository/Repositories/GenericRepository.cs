using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Common.IRepositories;
using Project.DAL.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Project.Repository.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IVehicleContext _context;

        public GenericRepository(IVehicleContext context)
        {
            this._context = context;
        }
        
        public async Task<Tentity> GetId<Tentity>(Guid id) where Tentity : class
        {
            return await _context.Set<Tentity>().FindAsync();
        }

        public async Task<int> Insert<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().AddOrUpdate(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> Table<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
