namespace BillGeneratorAPI.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<BillItem> Items { get; set; } = new();

        public string DiscountType { get; set; } = "none";
        public decimal DiscountValue { get; set; }
        public decimal TaxPercent { get; set; }

        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
    }
}