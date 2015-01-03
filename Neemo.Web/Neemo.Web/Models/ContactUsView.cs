using System.ComponentModel.DataAnnotations;

namespace Neemo.Web.Models
{
    public class ContactUsView
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(12)]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Comments { get; set; }

        public bool IsSubmitted { get; set; }
        public bool IsCaptchaNotValid { get; set; }
    }
}