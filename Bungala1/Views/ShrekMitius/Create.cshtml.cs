using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bungala1.Data;
using Bungala1.Models;

namespace Bungala1.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly Bungala1.Data.Bungala1Context _context;

        public CreateModel(Bungala1.Data.Bungala1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShrekMitiu ShrekMitiu { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShrekMitiu.Add(ShrekMitiu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
