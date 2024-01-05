using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWeb.Data;
using AppWeb.Models;

namespace AppWeb.Pages.Cuisines
{
    public class EditModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public EditModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cuisine Cuisine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cuisine == null)
            {
                return NotFound();
            }

            var cuisine =  await _context.Cuisine.FirstOrDefaultAsync(m => m.ID == id);
            if (cuisine == null)
            {
                return NotFound();
            }
            Cuisine = cuisine;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cuisine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuisineExists(Cuisine.ID))
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

        private bool CuisineExists(int id)
        {
          return (_context.Cuisine?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
