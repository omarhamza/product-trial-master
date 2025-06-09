using Microsoft.AspNetCore.Mvc;
using ProductTrial.Application.Interfaces;
using ProductTrial.Domain.Entities;

namespace ProductTrial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        //private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,
            //IProductRepository productRepository, 
            IProductService productService)
        {
            _logger = logger;
            //_productRepository = productRepository;
            _productService = productService;
        }

        [HttpGet]
        public Task<IEnumerable<Product>> Get()
        {
            return _productService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add(Product product)
        {
            var createdProduct = await _productService.CreateAsync(product);

            return CreatedAtAction(
                $"ProductId_{createdProduct.Id}",
                new { id = createdProduct.Id },
                createdProduct
            );
        }
    }
}
