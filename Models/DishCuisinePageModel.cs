using Microsoft.AspNetCore.Mvc.RazorPages;
using AppWeb.Data;
namespace AppWeb.Models
{
    public class DishCuisinePageModel : PageModel
    {
        public List<CuisineData> CuisineDataList;
        public void PopulateCuisineData(AppWebContext context,
        Menu menu)
        {
            var allCuisines = context.Cuisine;
            var menuCuisines = new HashSet<int>(
            menu.DishCuisines.Select(c => c.CuisineID)); //
            CuisineDataList = new List<CuisineData>();
            foreach (var cat in allCuisines)
            {
                CuisineDataList.Add(new CuisineData
                {
                    CuisineID = cat.ID,
                    Name = cat.CuisineName,
                    Assigned = menuCuisines.Contains(cat.ID)
                });
            }
        }
        public void UpdateDishCuisines(AppWebContext context,
        string[] selectedCuisines, Menu menuToUpdate)
        {
            if (selectedCuisines == null)
            {
                menuToUpdate.DishCuisines = new List<DishCuisine>();
                return;
            }
            var selectedCuisinesHS = new HashSet<string>(selectedCuisines);
            var menuCuisines = new HashSet<int>
            (menuToUpdate.DishCuisines.Select(c => c.Cuisine.ID));
            foreach (var cat in context.Cuisine)
            {
                if (selectedCuisinesHS.Contains(cat.ID.ToString()))
                {
                    if (!menuCuisines.Contains(cat.ID))
                    {
                        menuToUpdate.DishCuisines.Add(
                        new DishCuisine
                        {
                            MenuID = menuToUpdate.ID,
                            CuisineID = cat.ID
                        });
                    }
                }
                else
                {
                    if (menuCuisines.Contains(cat.ID))
                    {
                        DishCuisine courseToRemove
                        = menuToUpdate
                        .DishCuisines
                        .SingleOrDefault(i => i.CuisineID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
