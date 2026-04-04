using BillGeneratorAPI.Models;

namespace BillGeneratorAPI.Data
{
    public static class AppData
    {
        public static List<CatalogItem> CatalogItems = new()
        {
            new CatalogItem { Id = 1, Name = "Adult Ticket", CatalogType = CatalogType.EntranceFee, Price = 200, IsVariablePrice = false },
            new CatalogItem { Id = 2, Name = "Child Ticket", CatalogType = CatalogType.EntranceFee, Price = 100, IsVariablePrice = false },
            new CatalogItem { Id = 3, Name = "Senior Ticket", CatalogType = CatalogType.EntranceFee, Price = 150, IsVariablePrice = false },
            new CatalogItem { Id = 4, Name = "VIP Ticket", CatalogType = CatalogType.EntranceFee, Price = 500, IsVariablePrice = false },

            new CatalogItem { Id = 5, Name = "Donation - 100", CatalogType = CatalogType.Donation, Price = 100, IsVariablePrice = false },
            new CatalogItem { Id = 6, Name = "Donation - 500", CatalogType = CatalogType.Donation, Price = 500, IsVariablePrice = false },
            new CatalogItem { Id = 7, Name = "Donation - 1000", CatalogType = CatalogType.Donation, Price = 1000, IsVariablePrice = false },
            new CatalogItem { Id = 8, Name = "Custom Donation", CatalogType = CatalogType.Donation, Price = 0, IsVariablePrice = true },

            new CatalogItem { Id = 9, Name = "T-Shirt", CatalogType = CatalogType.SellingPrice, Price = 350, IsVariablePrice = true },
            new CatalogItem { Id = 10, Name = "Cap", CatalogType = CatalogType.SellingPrice, Price = 200, IsVariablePrice = true },
            new CatalogItem { Id = 11, Name = "Coffee", CatalogType = CatalogType.SellingPrice, Price = 80, IsVariablePrice = true },
            new CatalogItem { Id = 12, Name = "Guide Service", CatalogType = CatalogType.SellingPrice, Price = 1000, IsVariablePrice = true }
        };

        public static List<Bill> Bills = new();
    }
}