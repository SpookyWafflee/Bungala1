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
    public class IndexModel : PageModel
    {
        private readonly Bungala1.Data.Bungala1Context _context;

        public IndexModel(Bungala1.Data.Bungala1Context context)
        {
            _context = context;
        }

        public IList<ShrekMitiu> ShrekMitiu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ShrekMitiu = await _context.ShrekMitiu.ToListAsync();
        }
    }
}
