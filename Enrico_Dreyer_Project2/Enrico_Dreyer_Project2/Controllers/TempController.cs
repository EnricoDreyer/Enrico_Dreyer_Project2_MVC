using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Enrico_Dreyer_Project2.Controllers
{
    public class TempController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
