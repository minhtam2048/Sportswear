using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<Brand> brandRepository, IGenericRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products = await _productRepository.GetListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return Ok(product);
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