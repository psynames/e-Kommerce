using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace CORE.Specifications
{
   public  class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(int id)
            :base(x =>x.Id==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

        }
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        } 
    }
}
