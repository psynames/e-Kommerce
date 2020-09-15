using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Specifications
{
    public class productWithFiltersForCountSpecifications : BaseSpecification<Product>
    {
        public productWithFiltersForCountSpecifications(ProductSpecParams productSpecParams)
              : base(x =>
          (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) &&
          (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
          )
        {

        }
    }
}
