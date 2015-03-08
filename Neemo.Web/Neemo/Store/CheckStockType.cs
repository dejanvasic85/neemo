namespace Neemo.Store
{
    public enum CheckStockType
    {
        InStock,
        NotAvailable,
        RequestTooLarge
    }

    public class CheckStockResult
    {
        public CheckStockType StockCheck { get; set; }
        public Product Product { get; set; }
    }
}