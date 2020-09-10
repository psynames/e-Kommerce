using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CORE.Specifications
{
   public  class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        } 
    }
}
