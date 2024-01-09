using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppWeb.Data;
using AppWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppWeb.Pages.Dishes
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : DishCuisinePageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public CreateModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ChefID"] = new SelectList(_context.Set<Chef>(), "ID", "FullName");
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "LocationName");

            var menu = new Menu();
            menu.DishCuisines = new List<DishCuisine>();
            PopulateCuisineData(_context, menu);

            return Page();
        }

        [BindProperty]
        public Menu Menu { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCuisines)
        {
            var newMenu = new Menu();
            if (selectedCuisines != null)
            {
                newMenu.DishCuisines = new List<DishCuisine>();
                foreach (var cat in selectedCuisines)
                {
                    var catToAdd = new DishCuisine
                    {
                        CuisineID = int.Parse(cat)
                    };
                    newMenu.DishCuisines.Add(catToAdd);
                }
            }
            Menu.DishCuisines = newMenu.DishCuisines;
            _context.Menu.Add(Menu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
