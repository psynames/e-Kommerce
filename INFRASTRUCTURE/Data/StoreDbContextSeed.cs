using Microsoft.Extensions.Logging;

using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Text.Json;
using CORE.Entities;
using System.Collections.Generic;
using System;

namespace INFRASTRUCTURE.Data
{
    public class StoreDbContextSeed
    {
        public static async Task SeedAsync(StoreDbContext dbcontext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!dbcontext.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../INFRASTRUCTURE/DATA/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        dbcontext.ProductBrands.Add(item);
                    }

                    await dbcontext.SaveChangesAsync();
                }

                if (!dbcontext.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../INFRASTRUCTURE/DATA/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        dbcontext.ProductTypes.Add(item);
                    }

                    await dbcontext.SaveChangesAsync();
                }

                if (!dbcontext.Products.Any())
                {
                    var productsData = File.ReadAllText("../INFRASTRUCTURE/DATA/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        dbcontext.Products.Add(item);
                    }

                    await dbcontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
