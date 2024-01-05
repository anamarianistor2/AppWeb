using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppWeb.Data;
using AppWeb.Models;

namespace AppWeb.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public IndexModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reservation != null)
            {
                Reservation = await _context.Reservation
                .Include(r => r.Client)
                .Include(r => r.Location)
                
                .ToListAsync();
            }
        }
    }
}
