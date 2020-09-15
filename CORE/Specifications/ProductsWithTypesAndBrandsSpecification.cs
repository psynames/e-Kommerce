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
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams)
          : base(x=>
          (!productSpecParams.BrandId.HasValue || x.ProductBrandId ==productSpecParams.BrandId) &&
          (!productSpecParams.TypeId.HasValue  || x.ProductTypeId==productSpecParams.TypeId)
          )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpecParams.pageSize * (productSpecParams.PageIndex - 1),
                productSpecParams.pageSize);


            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;

                }
            }
        } 
    }
}
