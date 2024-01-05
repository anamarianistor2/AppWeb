using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppWeb.Data;
using AppWeb.Models;

namespace AppWeb.Pages.Chefs
{
    public class IndexModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public IndexModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

        public IList<Chef> Chef { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Chef != null)
            {
                Chef = await _context.Chef.ToListAsync();
            }
        }
    }
}
