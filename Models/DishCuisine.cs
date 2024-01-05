namespace AppWeb.Models
{
    public class DishCuisine
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public Menu Menu { get; set; }
        public int CuisineID { get; set; }
        public Cuisine Cuisine { get; set; }
    }
}
