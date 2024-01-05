using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppWeb.Data;
using AppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWeb.Pages.Reservations
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
            var dishList = _context.Location
                .Include(b => b.LocationName)
                .Select(x => new
                {
                    x.ID,
                    LocationFullName = x.LocationName                 });
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
        ViewData["LocationID"] = new SelectList(_context.Location, "ID", "LocationName");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reservation == null || Reservation == null)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
