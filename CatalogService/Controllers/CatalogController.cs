using CatalogService.Model;
using CatalogService.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly IMediator _mediator;

        public CatalogController(ILogger<CatalogController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator=mediator;
        }

        [HttpGet("GetProduct/{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetProduct(int id)
        {
            // var product = new Product() { ProductId=id, Name="Prodotto Test", Category=new Category() { CategoryId=1, Name="Categoria Test" } };
            // return Ok(await Task.Run(()=>product));            

            var product=await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetProducts()
        {
            // var product = new Product() { ProductId=id, Name="Prodotto Test", Category=new Category() { CategoryId=1, Name="Categoria Test" } };
            // return Ok(await Task.Run(()=>product));            

            var product=await _mediator.Send(new GetProductsQuery());
            return Ok(product);
        }
    }
}