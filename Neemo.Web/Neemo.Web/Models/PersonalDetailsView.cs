using System.ComponentModel.DataAnnotations;

namespace Neemo.Web.Models
{
    public class PersonalDetailsView
    {
        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Company")]
        [StringLength(50)]
        public string Company { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Suburb")]
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(50)]
        public string State { get; set; }

        [Display(Name = "Post Code")]
        [MaxLength(4)]
        [Required]
        public string Postcode { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(12)]
        [Required]
        public string PhoneNumber { get; set; }

    }
}