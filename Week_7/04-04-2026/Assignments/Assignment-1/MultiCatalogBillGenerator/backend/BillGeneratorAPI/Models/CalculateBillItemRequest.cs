namespace BillGeneratorAPI.Models
{
    public class CalculateBillItemRequest
    {
        public string ItemName { get; set; } = string.Empty;
        public CatalogType CatalogType { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}