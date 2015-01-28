using System.Collections.Generic;

namespace Neemo.Web.Models
{
    public class InvoiceDetailView
    {
        public string InvoiceNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public PersonalDetailsView BillingDetailsView { get; set; }
        public List<InvoiceItemView> InvoiceLineItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Shipping { get; set; }
        public decimal GrandTotal { get; set; }
        public int OrderId { get; set; }
    }
}