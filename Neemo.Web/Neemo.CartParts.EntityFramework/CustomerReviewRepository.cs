using Dapper;
using Neemo.CustomerReviews;

namespace Neemo.CarParts.EntityFramework
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        public void Create(CustomerReview customerReview)
        {
            using (var conn = DbContextFactory.CreateConnection())
            {
                
            }
        }
    }
}
