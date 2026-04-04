using BillGeneratorAPI.Data;
using BillGeneratorAPI.Models;
using BillGeneratorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillGeneratorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly BillService _billService;

        public BillController(AppDbContext context, BillService billService)
        {
            _context = context;
            _billService = billService;
        }

        // Calculate Bill
        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CalculateBillRequest request)
        {
            var result = _billService.CalculateBill(request);
            return Ok(result);
        }

        // Save Bill
        [HttpPost]
        public async Task<IActionResult> SaveBill([FromBody] CalculateBillRequest request)
        {
            var calculatedBill = _billService.CalculateBill(request);

            calculatedBill.InvoiceNumber = _billService.GenerateInvoiceNumber();
            calculatedBill.CreatedAt = DateTime.Now;

            _context.Bills.Add(calculatedBill);
            await _context.SaveChangesAsync();

            return Ok(calculatedBill);
        }

        // FIX FOR 405 ERROR
        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            var bills = await _context.Bills
                .Include(b => b.Items)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return Ok(bills);
        }

        // FIX FOR 404 ERROR
        [HttpGet("daily-summary")]
        public async Task<IActionResult> DailySummary()
        {
            var today = DateTime.Today;

            var todaysBills = await _context.Bills
                .Where(x => x.CreatedAt.Date == today)
                .ToListAsync();

            return Ok(new
            {
                date = today.ToString("yyyy-MM-dd"),
                totalBills = todaysBills.Count,
                totalSales = todaysBills.Sum(x => x.GrandTotal)
            });
        }
    }
}