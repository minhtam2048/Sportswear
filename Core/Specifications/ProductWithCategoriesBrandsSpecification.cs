using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithCategoriesBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithCategoriesBrandsSpecification()
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }

        public ProductWithCategoriesBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }
    }
}