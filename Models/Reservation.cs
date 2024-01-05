using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        [Display(Name = "Client")]
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        [Display(Name = "Location")]
        public int? LocationID { get; set; }
        public Location? Location { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ReservationDateTime { get; set; }
    }
}
