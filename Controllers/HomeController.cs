using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using ASPNET_Test2.Models;

namespace ASPNET_Test2.Controllers
{
    public class HomeController : Controller
    {
        public CryptocurrencyList result = new CryptocurrencyList();
        
        [HttpGet]
        public ActionResult Index(string name = @"")
        {
            result.search(name);
            return View(result);            
        }
    }
}
