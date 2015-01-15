using System.Collections.Generic;
using System.Linq;

namespace Neemo.Tax
{
    public static class TaxCostExtensions
    {
        /// <summary>
        /// Returns the sum of multiple tax amounts
        /// </summary>
        public static TaxCost TaxCostSum(this IEnumerable<TaxCost> taxes)
        {
            var taxesToSum = taxes.ToList();

            if (taxesToSum.Count == 0)
                return null;

            // Take the first tax cost
            var total = new TaxCost(taxesToSum.First().TaxType);

            return taxesToSum.Aggregate(total, (current, tax) => current + tax);
        }
    }
}