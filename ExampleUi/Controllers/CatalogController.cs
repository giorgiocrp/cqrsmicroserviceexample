using ExampleUi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExampleUi.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var product=
            return View();
        }

        public IActionResult GetAll()
        {
            return View();
        }       
    }
}