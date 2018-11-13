using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingLab.Models;

namespace ModelBindingLab.Controllers
{
    public class ProductController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

 
        public IActionResult Create(string name,int price)
        {
            // Save to database
            ViewData["name"] = name;
            ViewData["price"] = price;
            return View("Details");
        }
        public IActionResult Create1(string name, int price)
        {
            // Save to database
            ViewData["name"] = name;
            ViewData["price"] = price;
            return View("Details");
        }
        public IActionResult Create2(Product model)
        {
            // Save to database
            ViewData["name"] = model.Name;
            ViewData["price"] = model.Price;
            return View("Details");
        }

        [Route("/Create/List")]
        [HttpGet]
        public IActionResult CreateList()
        {
        
            return View();
        }

        [HttpPost]
        [Route("/Create/List")]
        public IActionResult CreateList(IList<Product> model)
        {

            return View("List", model);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        public async Task<IActionResult> Upload([FromServices] IHostingEnvironment _env,  List<IFormFile> files)
        {
            var path = _env.ContentRootPath + @"\files\";
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = path + formFile.FileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }



    }
}