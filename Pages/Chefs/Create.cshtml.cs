using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppWeb.Data;
using AppWeb.Models;

namespace AppWeb.Pages.Chefs
{
    public class CreateModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public CreateModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Chef Chef { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Chef == null || Chef == null)
            {
                return Page();
            }

            _context.Chef.Add(Chef);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
