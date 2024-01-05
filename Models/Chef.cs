using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    public class Chef
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Chef Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
