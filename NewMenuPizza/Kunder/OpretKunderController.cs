using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewMenuPizza.Kunder
{
    public class OpretKunderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}