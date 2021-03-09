using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithCategoriesBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithCategoriesBrandsSpecification(string sort, int? brandId, int? categoryId)
            : base (x => 
                (!brandId.HasValue || x.BrandId == brandId) &&
                (!categoryId.HasValue || x.CategoryId == categoryId)
            )
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(n => n.Name);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductWithCategoriesBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }
    }
}