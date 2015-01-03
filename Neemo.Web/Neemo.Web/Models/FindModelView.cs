using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Neemo.Web.Models
{
    public class FindModelView
    {
        public FindModelView()
        {
            ProductResults = new List<ProductSummaryView>();
            Page = 1;
            PageSize = 2;
            SortByItems = new List<SelectListItem>
            {
                new SelectListItem{Text = "Newest First", Value = "NewestFirst"},
                new SelectListItem{Text = "Oldest First", Value = "OldestFirst"},
                new SelectListItem{Text = "Price Lowest", Value = "PriceLowest"},
                new SelectListItem{Text = "Price Highest", Value = "PriceHighest"},
            };
        }
        public string Keyword { get; set; }

        public int? CategoryId { get; set; }

        [Display(Name = "Price Min")]
        public decimal? PriceMin { get; set; }

        [Display(Name = "Price Max")]
        public decimal? PriceMax { get; set; }

        [Display(Name = "Sort By")]
        public FindModelSortByView SortBy { get; set; }

        public IEnumerable<SelectListItem> SortByItems { get; set; }

        public int? PageSize { get; set; }

        public int? Page { get; set; }

        public List<ProductSummaryView> ProductResults { get; set; }

        public bool HasResults
        {
            get { return this.ProductResults.Count > 0; }
        }
        
        public bool HasPages
        {
            get { return this.ProductResultPageCount > 1; }
        }

        public int SkipAmount
        {
            get { return PageSize.GetValueOrDefault()*Page.GetValueOrDefault(); }
        }

        public int TotalResultCount { get; set; }

        public int ProductResultPageCount
        {
            get { return TotalResultCount/PageSize.GetValueOrDefault(); }
        }
    }

    public enum FindModelSortByView
    {
        NewestFirst,
        OldestFirst,
        PriceLowest,
        PriceHighest
    }
}