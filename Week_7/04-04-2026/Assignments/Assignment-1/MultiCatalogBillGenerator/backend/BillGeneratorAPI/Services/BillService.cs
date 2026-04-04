using BillGeneratorAPI.Models;

namespace BillGeneratorAPI.Services
{
    public class BillService
    {
        public Bill CalculateBill(CalculateBillRequest request)
        {
            var billItems = request.Items.Select(i => new BillItem
            {
                ItemName = i.ItemName,
                CatalogType = i.CatalogType,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity
            }).ToList();

            var subTotal = billItems.Sum(i => i.UnitPrice * i.Quantity);

            decimal discountAmount = 0;

            if ((request.DiscountType ?? "").ToLower() == "percentage")
            {
                discountAmount = subTotal * (request.DiscountValue / 100);
            }
            else if ((request.DiscountType ?? "").ToLower() == "fixed")
            {
                discountAmount = request.DiscountValue;
            }

            if (discountAmount > subTotal)
            {
                discountAmount = subTotal;
            }

            var taxableAmount = subTotal - discountAmount;
            var taxAmount = taxableAmount * (request.TaxPercent / 100);
            var grandTotal = taxableAmount + taxAmount;

            return new Bill
            {
                Items = billItems,
                DiscountType = request.DiscountType,
                DiscountValue = request.DiscountValue,
                TaxPercent = request.TaxPercent,
                SubTotal = subTotal,
                DiscountAmount = discountAmount,
                TaxAmount = taxAmount,
                GrandTotal = grandTotal
            };
        }

        public string GenerateInvoiceNumber()
        {
            return $"INV-{DateTime.Now:yyyyMMdd-HHmmss}";
        }
    }
}