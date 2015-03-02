
using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class HomeView
    {
        public HomeView()
        {
            SearchFilters = new FindModelView();
            NewProducts = new List<ProductSummaryView>();
            BestSellingProducts = new List<ProductSummaryView>();
            FeaturedProducts = new List<ProductSummaryView>();
        }
        public List<ProductSummaryView> FeaturedProducts { get; set; }
        public List<ProductSummaryView> NewProducts { get; set; }
        public List<ProductSummaryView> BestSellingProducts { get; set; }
        public FindModelView SearchFilters { get; set; }
    }
}