using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetMvcBeer.Models;
using ProjetMvcBeer.Data;

namespace ProjetMvcBeer.Controllers
{
    public class LigneDeVieDevisController : Controller
    {
        private readonly ProjetMvcBeerContext _context3;

        public LigneDeVieDevisController(ProjetMvcBeerContext context3)
        {
            _context3=context3;
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
