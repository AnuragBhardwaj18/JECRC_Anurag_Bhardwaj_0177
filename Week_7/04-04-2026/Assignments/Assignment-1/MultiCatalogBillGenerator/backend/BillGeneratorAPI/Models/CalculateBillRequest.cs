namespace BillGeneratorAPI.Models
{
    public class CalculateBillRequest
    {
        public List<CalculateBillItemRequest> Items { get; set; } = new();
        public string DiscountType { get; set; } = "none";
        public decimal DiscountValue { get; set; }
        public decimal TaxPercent { get; set; }
    }
}