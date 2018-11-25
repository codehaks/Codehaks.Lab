using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySession.Lab
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
         
            return Ok("Sessions!");
        }
        public IActionResult Send()
        {
            var message = $"Welcome to me at {DateTime.Now.ToShortTimeString()}";
            HttpContext.Session.SetString("message", message);
            return Ok(message);
        }
        public IActionResult Read()
        {
            var message=HttpContext.Session.GetString("message");
            if (string.IsNullOrEmpty( message))
            {
                return BadRequest("Session Not Found");
            }
            return Ok(message);
        }
    }
}
