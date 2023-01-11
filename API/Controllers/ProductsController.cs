using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
       
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
   
            var products = await _repository.GetProductsAsync();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Product/brands
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandsAsync()
        {
            return Ok(await _repository.GetProductBrandsAsync());
        }

        // GET: api/Product/brands
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypesAsync()
        {
            return Ok(await _repository.GetProductTypesAsync());
        }

    }
}
