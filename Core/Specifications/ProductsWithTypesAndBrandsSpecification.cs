using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        :  base(x =>
                    (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower()
                        .Contains(productParams.Search)) && 
                    (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                    (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
            addOrderBy(p => p.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
                productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort)) {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        addOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        addOrderByDescending(p => p.Price);
                        break;
                    default:
                        addOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id) {
            AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
        }
    }
}