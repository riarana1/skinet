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
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id) {
            AddInclude(t => t.ProductType);
            AddInclude(b => b.ProductBrand);
        }
    }
}