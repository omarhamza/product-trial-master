using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;
using ProductTrial.Domain.Models;

namespace ProductTrial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add(CreateProduct createdProduct)
        {
            var product = new Product
            {
                Category = createdProduct.Category,
                Code = createdProduct.Code,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Image = createdProduct.Image,
                InternalReference = createdProduct.InternalReference,
                InventoryStatus = createdProduct.InventoryStatus,
                Price = createdProduct.Price,
                Quantity = createdProduct.Quantity,
                Rating = createdProduct.Rating,
                ShellId = createdProduct.ShellId
            };

            await _productService.CreateAsync(product);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product
            );
        }
    }
}
