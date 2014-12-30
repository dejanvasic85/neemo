
using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class HomeView
    {
        public List<ProductSummaryView> FeaturedProducts { get; set; }
        public List<ProductSummaryView> NewProducts { get; set; }
    }
}