using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bungala1.Data;
using Bungala1.Models;

namespace Bungala1.Views.ShrekMitius
{
    public class EditModel : PageModel
    {
        private readonly Bungala1.Data.Bungala1Context _context;

        public EditModel(Bungala1.Data.Bungala1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ShrekMitiu ShrekMitiu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shrekmitiu =  await _context.ShrekMitiu.FirstOrDefaultAsync(m => m.Id == id);
            if (shrekmitiu == null)
            {
                return NotFound();
            }
            ShrekMitiu = shrekmitiu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShrekMitiu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShrekMitiuExists(ShrekMitiu.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShrekMitiuExists(int id)
        {
            return _context.ShrekMitiu.Any(e => e.Id == id);
        }
    }
}
