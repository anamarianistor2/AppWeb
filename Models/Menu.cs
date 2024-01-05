using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    public class Menu
    {
        public int ID { get; set; }

        [Display(Name = "Dish Name")]
        public string DishName { get; set; }



        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Chef")]
        public int? ChefID { get; set; }
        public Chef? Chef { get; set; }

        public ICollection<DishCuisine>? DishCuisines { get; set; }

        public int LocationID { get; set; }
        public Location? Location { get; set; }

        public int? ReservationID { get; set; }
        public Reservation? Reservation { get; set; }




    }
}
