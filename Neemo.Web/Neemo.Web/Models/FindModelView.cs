using System;
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
            PageSize = 5;
            SortByItems = new List<SelectListItem>
            {
                new SelectListItem{Text = "Newest First", Value = "NewestFirst"},
                new SelectListItem{Text = "Oldest First", Value = "OldestFirst"},
                new SelectListItem{Text = "Price Lowest", Value = "PriceLowest"},
                new SelectListItem{Text = "Price Highest", Value = "PriceHighest"},
            };
            PageSizeItems = new List<SelectListItem>
            {
                new SelectListItem {Text = "5", Value = "5"},
                new SelectListItem {Text = "10", Value = "10"},
                new SelectListItem {Text = "25", Value = "25"},
                new SelectListItem {Text = "50", Value = "50"},
                new SelectListItem {Text = "100", Value = "100"}
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

        public string Make { get; set; }

        public string Model { get; set; }

        public IEnumerable<SelectListItem> SortByItems { get; set; }

        public IEnumerable<SelectListItem> PageSizeItems { get; set; }

        public int PageSize { get; set; }

        public int Page { get; set; }

        public List<ProductSummaryView> ProductResults { get; set; }

        public bool HasResults
        {
            get { return this.ProductResults.Count > 0; }
        }
        
        public bool HasPages
        {
            get { return this.TotalPageCount > 1; }
        }

        public int SkipAmount
        {
            get { return PageSize*(Page - 1); }
        }

        public int TotalResultCount { get; set; }

        public int TotalPageCount
        {
            get { return (int)Math.Ceiling((double)TotalResultCount / PageSize); }
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