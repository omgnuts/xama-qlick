using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webng2.Controllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing

    /*
     * host:/admin
     * host:/admin/
     * host:/admin/hello
     * host:/admin/fishy - not work (overridden by hello)
     */

    [Route("[controller]")]
    //[Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        [Route("")]
        //[Route("/")]
        [Route("{*url}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("hello")]
        public string Fishy()
        {
            return "GET: This";
        }

        //[HttpGet]
        //public string Foody()
        //{
        //    return "GET: Food";
        //}
        //public IActionResult Error()
        //{
        //    return View();
        //}
    }
}
