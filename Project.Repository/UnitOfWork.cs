using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Common;
using Project.Repository.Common;

namespace Project.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IVehicleContext _context;
        private bool disposed = false;

        public UnitOfWork(IVehicleContext context)
        {
            this._context = context;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
