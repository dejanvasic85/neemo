using System;
using System.Collections.Generic;

namespace Neemo.CarParts.EntityFramework.Models
{
    public partial class Testimonial
    {
        public int TestimonialID { get; set; }
        public string Testimonial1 { get; set; }
        public string FullName { get; set; }
        public string Suburb { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<bool> Approved { get; set; }
    }
}
