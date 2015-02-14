
using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class HomeView
    {
        public HomeView()
        {
            this.SearchFilters = new FindModelView();
        }
        public List<ProductSummaryView> FeaturedProducts { get; set; }
        public List<ProductSummaryView> NewProducts { get; set; }
        public List<ProductSummaryView> BestSellingProducts { get; set; }
        public FindModelView SearchFilters { get; set; }
    }
}