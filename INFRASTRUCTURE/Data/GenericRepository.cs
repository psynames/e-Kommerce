using CORE.Entities;
using CORE.Interfaces;
using CORE.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly StoreDbContext _dbcontext;

        #endregion

        #region CONSTRUCTOR

        public GenericRepository(StoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #endregion

        #region public async Task<T> GetByIdAsync(int id)

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        #endregion

        #region public async Task<T> GetEntityWithSpec(ISpecification<T> spec)

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        #endregion

        #region  public async Task<IReadOnlyList<T>> ListAllAsync()

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        #endregion

        #region public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        #endregion

        #region private IQueryable<T> ApplySpecification(ISpecification<T> spec)

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>().AsQueryable(),spec);
        }

        #endregion
    }
}
