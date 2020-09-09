using CORE.Entities;
using CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTUCTURE.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbcontext;

        public ProductRepository(StoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbcontext.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _dbcontext.Products.ToListAsync();
        }
    }
}
