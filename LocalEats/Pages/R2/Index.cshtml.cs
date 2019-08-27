using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LocalEats.Core;
using LocalEats.Data;

namespace LocalEats.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly LocalEats.Data.LocalEatsDbContext _context;

        public IndexModel(LocalEats.Data.LocalEatsDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
