using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    public class Location
    {
        public int ID { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }
        public ICollection<Menu>? Dishes { get; set; }

        public string Reservation { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
