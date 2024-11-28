using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bungala1.Data;
using Bungala1.Models;

namespace Bungala1.Views.ShrekMitius
{
    public class DetailsModel : PageModel
    {
        private readonly Bungala1.Data.Bungala1Context _context;

        public DetailsModel(Bungala1.Data.Bungala1Context context)
        {
            _context = context;
        }

        public ShrekMitiu ShrekMitiu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shrekmitiu = await _context.ShrekMitiu.FirstOrDefaultAsync(m => m.Id == id);
            if (shrekmitiu == null)
            {
                return NotFound();
            }
            else
            {
                ShrekMitiu = shrekmitiu;
            }
            return Page();
        }
    }
}
