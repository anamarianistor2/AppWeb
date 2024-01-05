using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppWeb.Data;
using AppWeb.Models;

namespace AppWeb.Pages.Dishes
{
    public class DetailsModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public DetailsModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

      public Menu Menu { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FirstOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }
            else 
            {
                Menu = menu;
            }
            return Page();
        }
    }
}
