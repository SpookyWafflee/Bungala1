using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bungala1.Data;
using Bungala1.Models;

namespace Bungala1.Controllers
{
    public class ShrekMitiusController : Controller
    {
        private readonly Bungala1Context _context;

        public ShrekMitiusController(Bungala1Context context)
        {
            _context = context;
        }

        // GET: ShrekMitius
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShrekMitiu.ToListAsync());
        }

        // GET: ShrekMitius/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shrekMitiu = await _context.ShrekMitiu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shrekMitiu == null)
            {
                return NotFound();
            }

            return View(shrekMitiu);
        }

        // GET: ShrekMitius/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShrekMitius/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Seats,IsSmokerFriendly,IsPetFriendly,Location,PricePerNight")] ShrekMitiu shrekMitiu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shrekMitiu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shrekMitiu);
        }

        // GET: ShrekMitius/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shrekMitiu = await _context.ShrekMitiu.FindAsync(id);
            if (shrekMitiu == null)
            {
                return NotFound();
            }
            return View(shrekMitiu);
        }

        // POST: ShrekMitius/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Seats,IsSmokerFriendly,IsPetFriendly,Location,PricePerNight")] ShrekMitiu shrekMitiu)
        {
            if (id != shrekMitiu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shrekMitiu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShrekMitiuExists(shrekMitiu.Id))
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
            return View(shrekMitiu);
        }

        // GET: ShrekMitius/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shrekMitiu = await _context.ShrekMitiu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shrekMitiu == null)
            {
                return NotFound();
            }

            return View(shrekMitiu);
        }

        // POST: ShrekMitius/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shrekMitiu = await _context.ShrekMitiu.FindAsync(id);
            if (shrekMitiu != null)
            {
                _context.ShrekMitiu.Remove(shrekMitiu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShrekMitiuExists(int id)
        {
            return _context.ShrekMitiu.Any(e => e.Id == id);
        }
    }
}
