using ExampleUi.Models;
using ExampleUi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace ExampleUi.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger; 
        private readonly ICatalogService _catalogService;     

        public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Product product = await _catalogService.GetProductById(id);
            return View(product);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _catalogService.GetProducts();
            return View(products);
        }       
    }
}