using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySession.Lab
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Cookies!");
        }

        public IActionResult Send()
        {
            var message = $"Welcome to me at {DateTime.Now.ToShortTimeString()}";
            HttpContext.Response.Cookies.Append("message", message, new Microsoft.AspNetCore.Http.CookieOptions {
                //Domain = "codehaks.com",
                Path = "/shop",
                Expires=DateTimeOffset.Now.AddSeconds(10),                
                            
            });
            return Ok(message);
        
        }

        public IActionResult Read()
        {
            var message = HttpContext.Request.Cookies["message"];
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest("Cookie Not Found");
            }
            return Ok(message);
        }
    }
}
