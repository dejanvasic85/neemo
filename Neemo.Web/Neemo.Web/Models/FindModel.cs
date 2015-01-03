using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class FindModel
    {
        public string Keyword { get; set; }
        public int? CategoryId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public string SortBy { get; set; }
        public int? PageSize { get; set; }
        public int? Page { get; set; }

        public List<ProductSummaryView> ProductResults { get; set; } 
    }
}