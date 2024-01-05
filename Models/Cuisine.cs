namespace AppWeb.Models
{
    public class Cuisine
    {
        public int ID { get; set; }
        public string CuisineName { get; set; }
        public ICollection<DishCuisine>? DishCuisines { get; set; }
    }
}
