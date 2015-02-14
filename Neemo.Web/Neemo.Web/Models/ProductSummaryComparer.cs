using System;
using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class ProductSummaryComparer : IComparer<ProductSummaryView>
    {
        private readonly FindModelSortByView _sortBy;

        public ProductSummaryComparer(FindModelSortByView sortBy)
        {
            _sortBy = sortBy;
        }

        public int Compare(ProductSummaryView x, ProductSummaryView y)
        {
            var result = 0;

            switch (_sortBy)
            {
                case FindModelSortByView.PriceHighest:
                    result = y.Price.CompareTo(x.Price);
                    break;

                case FindModelSortByView.PriceLowest:
                    result = x.Price.CompareTo(y.Price);
                    break;

                case FindModelSortByView.OldestFirst:
                    result = y.CreatedDateTime.CompareTo(x.CreatedDateTime);
                    break;

                case FindModelSortByView.NewestFirst:
                    result = x.CreatedDateTime.CompareTo(y.CreatedDateTime);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}