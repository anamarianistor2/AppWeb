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
    public class DetailsModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public DetailsModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

      public Chef Chef { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chef == null)
            {
                return NotFound();
            }

            var chef = await _context.Chef.FirstOrDefaultAsync(m => m.ID == id);
            if (chef == null)
            {
                return NotFound();
            }
            else 
            {
                Chef = chef;
            }
            return Page();
        }
    }
}
