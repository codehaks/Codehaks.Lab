using Microsoft.AspNetCore.Mvc;
using ModelBindingLab.Common;
using ModelBindingLab.Models;

namespace ModelBindingLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("get")]
        public IActionResult Get([ModelBinder(typeof(ProductBinder),Name ="Name")] Product product)
        {
            return Ok(product);
        }

    }
}