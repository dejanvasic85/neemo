using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Neemo.Providers;

namespace Neemo.Web.Models
{
    public class FindProvidersModel : IPagingModel
    {
        public FindProvidersModel()
        {
            ProviderSummaryViews = new List<ProviderSummaryView>();
            Page = 1;
            PageSize = 20;
            SortByItems = new List<SelectListItem>
            {
                new SelectListItem{Text = "Newest First", Value = "NewestFirst"},
                new SelectListItem{Text = "Oldest First", Value = "OldestFirst"},
            };
            PageSizeItems = new List<SelectListItem>
            {
                new SelectListItem {Text = "20", Value = "20"},
                new SelectListItem {Text = "40", Value = "40"},
                new SelectListItem {Text = "80", Value = "80"},
                new SelectListItem {Text = "100", Value = "100"},
                new SelectListItem {Text = "200", Value = "200"}
            };
        }

        public ProviderType ProviderType { get; set; }
        public string Keyword { get; set; }
        public string ProviderSuburb { get; set; }

        public int? CategoryId { get; set; }

        [Display(Name = "Price Min")]
        public decimal? PriceMin { get; set; }

        [Display(Name = "Price Max")]
        public decimal? PriceMax { get; set; }

        [Display(Name = "Sort By")]
        public FindModelSortByView SortBy { get; set; }

        public IEnumerable<SelectListItem> SortByItems { get; set; }

        public IEnumerable<SelectListItem> PageSizeItems { get; set; }

        public int PageSize { get; set; }

        public int Page { get; set; }

        public IEnumerable<SelectListItem> PageOptions
        {
            get
            {
                for (int i = 1; i <= TotalPageCount; i++)
                {
                    yield return new SelectListItem
                    {
                        Text = i.ToString(),
                        Value = i.ToString(),
                        Selected = this.Page == i
                    };
                }
            }
        }
        public List<ProviderSummaryView> ProviderSummaryViews { get; set; }

        public bool HasResults
        {
            get { return this.ProviderSummaryViews.Count > 0; }
        }

        public bool HasPages
        {
            get { return this.TotalPageCount > 1; }
        }

        public int SkipAmount
        {
            get { return PageSize * (Page - 1); }
        }

        public int TotalResultCount { get; set; }

        public int TotalPageCount
        {
            get { return (int)Math.Ceiling((double)TotalResultCount / PageSize); }
        }

        public int? ProviderServiceType { get; set; }
        public string ProviderState { get; set; }
        public int? Make { get; set; }
    }
}