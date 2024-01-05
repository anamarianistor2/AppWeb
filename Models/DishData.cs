namespace AppWeb.Models
{
    public class DishData
    {
        public IEnumerable<Menu> Dishes { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<DishCuisine> DishCuisines { get; set; }
    }
}
