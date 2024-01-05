using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppWeb.Data;
using AppWeb.Models;

namespace AppWeb.Pages.Cuisines
{
    public class DetailsModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public DetailsModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

      public Cuisine Cuisine { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cuisine == null)
            {
                return NotFound();
            }

            var cuisine = await _context.Cuisine.FirstOrDefaultAsync(m => m.ID == id);
            if (cuisine == null)
            {
                return NotFound();
            }
            else 
            {
                Cuisine = cuisine;
            }
            return Page();
        }
    }
}
