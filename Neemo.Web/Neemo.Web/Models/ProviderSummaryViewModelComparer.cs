using System;
using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class ProviderSummaryViewModelComparer : IComparer<ProviderSummaryView>
    {
        private readonly FindModelSortByView _sortBy;

        public ProviderSummaryViewModelComparer(FindModelSortByView sortBy)
        {
            _sortBy = sortBy;
        }

        public int Compare(ProviderSummaryView x, ProviderSummaryView y)
        {
            var result = 0;

            switch (_sortBy)
            {
                case FindModelSortByView.OldestFirst:
                    result = y.CreatedDateTime.CompareTo(x.CreatedDateTime);
                    break;

                case FindModelSortByView.NewestFirst:
                    result = x.CreatedDateTime.CompareTo(y.CreatedDateTime);
                    break;

                case FindModelSortByView.BestRatingFirst:
                    result = y.Rating.GetValueOrDefault().CompareTo(x.Rating.GetValueOrDefault());
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}