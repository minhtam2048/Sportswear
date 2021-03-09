using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<Brand> brandRepository, IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(
            string sort, int? brandId, int? categoryId)
        {
            var spec = new ProductWithCategoriesBrandsSpecification(sort, brandId, categoryId);

            var products = await _productRepository.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithCategoriesBrandsSpecification(id);

            var product = await _productRepository.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new APIResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetProductCategories()
        {
            var categories = await _categoryRepository.GetListAsync();
            return Ok(categories);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetProductBrands()
        {
            var brands = await _brandRepository.GetListAsync();
            return Ok(brands);
        }
    }
}