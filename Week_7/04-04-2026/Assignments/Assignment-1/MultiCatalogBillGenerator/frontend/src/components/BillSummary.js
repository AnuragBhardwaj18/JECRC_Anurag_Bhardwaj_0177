function BillSummary({
  discountType,
  setDiscountType,
  discountValue,
  setDiscountValue,
  taxPercent,
  setTaxPercent,
  summary,
  saveDraft,
  saveBill,
  exportPdf,
  exportCsv,
  printBill
}) {
  return (
    <div className="card">
      <h2>Bill Settings</h2>

      <label>Discount Type</label>
      <select value={discountType} onChange={(e) => setDiscountType(e.target.value)}>
        <option value="none">None</option>
        <option value="percentage">Percentage</option>
        <option value="fixed">Fixed</option>
      </select>

      <label>Discount Value</label>
      <input
        type="number"
        min="0"
        value={discountValue}
        onChange={(e) => setDiscountValue(e.target.value)}
      />

      <label>Tax %</label>
      <input
        type="number"
        min="0"
        value={taxPercent}
        onChange={(e) => setTaxPercent(e.target.value)}
      />

      <div className="summary-box">
        <p><strong>Subtotal:</strong> ₹ {summary.subTotal}</p>
        <p><strong>Discount:</strong> ₹ {summary.discountAmount}</p>
        <p><strong>Tax:</strong> ₹ {summary.taxAmount}</p>
        <p><strong>Grand Total:</strong> ₹ {summary.grandTotal}</p>
      </div>

      <div className="action-buttons">
        <button onClick={saveDraft}>Save Draft</button>
        <button onClick={saveBill}>Save Bill</button>
        <button onClick={exportPdf}>Export PDF</button>
        <button onClick={exportCsv}>Export CSV</button>
        <button onClick={printBill}>Print</button>
      </div>
    </div>
  );
}

export default BillSummary;