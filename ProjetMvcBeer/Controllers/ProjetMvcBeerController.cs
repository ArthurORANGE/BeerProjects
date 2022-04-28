using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetMvcBeer.Models;
using ProjetMvcBeer.Data;
//using PagedList;
//using PagedList.Mvc;


namespace ProjetMvcBeer.Controllers
{
    public class ProjetMvcBeerController : Controller
    {
        private readonly ProjetMvcBeerContext _context;

        public ProjetMvcBeerController(ProjetMvcBeerContext context)
        {
            _context = context;
        }


        // GET: beers
        public async Task<IActionResult> Index(string beerCategory, string sortOrder, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Beer orderby b.Category select b.Category;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

            var beer = from b in _context.Beer select b;

            switch (sortOrder)
            {
                case "title_desc":
                    beer = beer.OrderByDescending(s => s.Title);
                    break;
                default:
                    beer = beer.OrderBy(s => s.Title);
                    break;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                beer = beer.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(beerCategory))
            {
                beer = beer.Where(c => c.Category == beerCategory);
            }


            var beerCategoryVM = new BeerCategoryViewModel
            {
                Category = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Beers = await beer.ToListAsync()
            };

            return View(beerCategoryVM);

        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: ProjetMvcBeer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer
                .FirstOrDefaultAsync(m => m.BeerID == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // GET: ProjetMvcBeer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjetMvcBeer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Category,Price,AlcoolDegree,Size,Image")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beer);
        }

        // GET: ProjetMvcBeer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            return View(beer);
        }

        // POST: ProjetMvcBeer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Category,Price,AlcoolDegree,Size,Image")] Beer beer)
        {
            if (id != beer.BeerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerExists(beer.BeerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beer);
        }

        // GET: ProjetMvcBeer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer
                .FirstOrDefaultAsync(m => m.BeerID == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: ProjetMvcBeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beer = await _context.Beer.FindAsync(id);
            _context.Beer.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerExists(int id)
        {
            return _context.Beer.Any(e => e.BeerID == id);
        }
    }
}
