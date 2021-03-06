﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingLab.Common;
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

         //[Route("product/create/{name}/{price}")]

         
        public IActionResult Create(string name,int price)
        {
            // Check valiation
            // Save to database

            ViewData["name"] = name;
            ViewData["price"] = price;
            return View("Details");
        }
        public IActionResult Create1()
        {
       
            return View("Create");
        }
        public IActionResult Create2([ModelBinder(typeof(ProductBinder))]Product product)
        {
            // Save to database
            ViewData["name"] = product.Name;
            ViewData["price"] = product.Price;
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


        [Route("/Create/info")]
        [HttpGet]
        public IActionResult CreateInfo()
        {
            return View();
        }

        [HttpPost]
        [Route("/Create/Info")]
        public IActionResult CreateInfo(ProductInfo model)
        {
            return View("Info", model);
        }

        [Route("/Create/full")]
        public IActionResult CreateFull()
        {
            return View();
        }

        [HttpPost]
        [Route("/Create/full")]
        public IActionResult CreateFull(Product product,Maker maker,IFormFile file,string note)
        {
            return View();
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