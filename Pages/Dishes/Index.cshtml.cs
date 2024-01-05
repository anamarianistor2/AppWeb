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
    public class IndexModel : PageModel
    {
        private readonly AppWeb.Data.AppWebContext _context;

        public IndexModel(AppWeb.Data.AppWebContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get; set; } = default!;
        public DishData DishD { get; set; }
        public int MenuID { get; set; }
        public int CuisineID { get; set; }

        public string DishNameSort { get; set; }
        public string ChefSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? cuisineID, string sortOrder, string searchString)
        {
            DishD = new DishData();

            DishNameSort = String.IsNullOrEmpty(sortOrder) ? "dishname_desc" : "";
            ChefSort = sortOrder == "chef" ? "chef_desc" : "chef";

            CurrentFilter = searchString;

            DishD.Dishes = await _context.Menu
            .Include(b => b.Chef)
            .Include(b => b.Location)
            .Include(b => b.DishCuisines)
            .ThenInclude(b => b.Cuisine)
            .AsNoTracking()
            .OrderBy(b => b.DishName)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                DishD.Dishes = DishD.Dishes.Where(s => s.Chef.FirstName.Contains(searchString)

               || s.Chef.LastName.Contains(searchString)
               || s.DishName.Contains(searchString));

                if (id != null)
                {
                    MenuID = id.Value;
                    Menu menu = DishD.Dishes
                    .Where(i => i.ID == id.Value).Single();
                    DishD.Cuisines = menu.DishCuisines.Select(s => s.Cuisine);
                }

                switch (sortOrder)
                {
                    case "dishname_desc":
                        DishD.Dishes = DishD.Dishes.OrderByDescending(s =>
                       s.DishName);
                        break;
                    case "chef_desc":
                        DishD.Dishes = DishD.Dishes.OrderByDescending(s =>
                       s.Chef.FullName);
                        break;
                    case "chef":
                        DishD.Dishes = DishD.Dishes.OrderBy(s =>
                       s.Chef.FullName);
                        break;
                    default:
                        DishD.Dishes = DishD.Dishes.OrderBy(s => s.DishName);
                        break;
                }


            }
        }
    }
}
