using BillGeneratorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BillGeneratorAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bill>()
                .HasMany(b => b.Items)
                .WithOne(i => i.Bill)
                .HasForeignKey(i => i.BillId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BillItem>()
                .Ignore(i => i.LineTotal);

            modelBuilder.Entity<CatalogItem>().HasData(
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
            );
        }
    }
}