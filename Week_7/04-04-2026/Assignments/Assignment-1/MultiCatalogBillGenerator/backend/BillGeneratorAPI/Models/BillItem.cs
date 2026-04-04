using System.Text.Json.Serialization;

namespace BillGeneratorAPI.Models
{
    public class BillItem
    {
        public int Id { get; set; }

        // Foreign Key
        public int BillId { get; set; }

        
        [JsonIgnore]
        public Bill? Bill { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public CatalogType CatalogType { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        
        public decimal LineTotal => UnitPrice * Quantity;
    }
}