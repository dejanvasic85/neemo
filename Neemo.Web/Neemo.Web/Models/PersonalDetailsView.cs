using System.ComponentModel.DataAnnotations;

namespace Neemo.Web.Models
{
    public class PersonalDetailsView
    {
        [Display(Name = "First Name")]
        [Required]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Post Code")]
        [Required]
        public string Postcode { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

    }
}