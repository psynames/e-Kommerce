using CORE.Entities;
using CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
