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

namespace AppWeb.Pages.Dishes
{
    public class EditModel : DishCuisinePageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public EditModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu Menu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }
            Menu = await _context.Menu
            .Include(b => b.DishCuisines).ThenInclude(b => b.Cuisine)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            var menu =  await _context.Menu.FirstOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }
            PopulateCuisineData(_context, Menu);
            Menu = menu;
            ViewData["ChefID"] = new SelectList(_context.Set<Chef>(), "ID", "FullName");
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "LocationName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCuisines)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuToUpdate = await _context.Menu
            .Include(i => i.DishCuisines)
            .ThenInclude(i => i.Cuisine)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (menuToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Menu>(
            menuToUpdate,
            "Menu",
            i => i.DishName, i => i.Chef,
            i => i.Price, i => i.DateAdded))
            {
                UpdateDishCuisines(_context, selectedCuisines, menuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateDishCuisines(_context, selectedCuisines, menuToUpdate);
            PopulateCuisineData(_context, menuToUpdate);
            return Page();

        }
    }
}
