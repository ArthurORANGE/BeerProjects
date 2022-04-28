using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetMvcBeer.Models;
using ProjetMvcBeer.Data;

namespace ProjetMvcBeer.Controllers
{
    public class MonCompteController : Controller
    {
        private readonly ProjetMvcBeerContext _context3;

        public MonCompteController(ProjetMvcBeerContext context3)
        {
            _context3 = context3;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Information()
        {

            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        
    }
}