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
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
            addOrderBy(p => p.Name);

            if (!string.IsNullOrEmpty(sort)) {
                switch (sort)
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