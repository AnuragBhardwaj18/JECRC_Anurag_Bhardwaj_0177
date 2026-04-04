namespace BillGeneratorAPI.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public CatalogType CatalogType { get; set; }
        public decimal Price { get; set; }
        public bool IsVariablePrice { get; set; } = false;
    }
}