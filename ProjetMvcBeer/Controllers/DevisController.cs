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
    public class DevisController : Controller
    {
        private readonly ProjetMvcBeerContext _context2;

        public DevisController(ProjetMvcBeerContext context2)
        {
            _context2 = context2;
        }



        public async Task<IActionResult> Index(string sortOrder,string currentFilter,string searchString,int? pageNumber)
        {
            ViewData["ClientSortParm"] = String.IsNullOrEmpty(sortOrder) ? "client_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var devis = from d in _context2.Devis select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                devis = devis.Where(d => d.Title.Contains(searchString));
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    devis = devis.OrderByDescending(d => d.Title);
                    break;
                case "client_desc":
                    devis = devis.OrderByDescending(d => d.ClientName);
                    break;
                case "Date":
                    devis = devis.OrderBy(d => d.CreationDate);
                    break;
                case "date_desc":
                    devis = devis.OrderByDescending(d => d.CreationDate);
                    break;
                default:
                    devis = devis.OrderBy(d => d.Title);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Devis>.CreateAsync(devis.AsNoTracking(), pageNumber ?? 1, pageSize));
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,CreationDate,ClientName")] Devis devis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context2.Add(devis);
                    await _context2.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(devis);
        }


        // GET: ProjetMvcBeer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var devis = await _context2.Devis
                    .Include(l => l.ListeLigneDeVieDevis)
                    .ThenInclude(b => b.Beer)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (devis == null)
            {
                return NotFound();
            }

            return View(devis);
        }


        // GET: ProjetMvcBeer/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devis = await _context2.Devis
                .FirstOrDefaultAsync(d => d.Id == id);
            if (devis == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(devis);
        }

        // POST: ProjetMvcBeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devis = await _context2.Devis.FindAsync(id);
            if (devis == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context2.Devis.Remove(devis);
                await _context2.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }


        // GET: ProjetMvcBeer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devis = await _context2.Devis.Include(l => l.ListeLigneDeVieDevis)
                    .ThenInclude(b => b.Beer).AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);;
            if (devis == null)
            {
                return NotFound();
            }

            return View(devis);
        }

        // POST: ProjetMvcBeer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreationDate,ClientName,TotalPrice,Quantity")] Devis devis )
        {
            if (id != devis.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                
                try
                {
                    _context2.Update(devis);
                    await _context2.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(devis);
        }


         private bool DevisExists(int id)
        {
            return _context2.Devis.Any(d => d.Id == id);
        }

    }
}
