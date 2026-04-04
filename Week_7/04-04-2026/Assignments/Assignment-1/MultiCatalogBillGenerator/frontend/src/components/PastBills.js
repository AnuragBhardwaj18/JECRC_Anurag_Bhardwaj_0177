function PastBills({ searchText, setSearchText, filteredBills }) {
  return (
    <div className="card">
      <h2>Past Bills</h2>

      <input
        type="text"
        placeholder="Search invoice or item..."
        value={searchText}
        onChange={(e) => setSearchText(e.target.value)}
      />

      <div className="past-bills">
        {filteredBills.length === 0 ? (
          <p>No bills found.</p>
        ) : (
          filteredBills.map((bill, index) => (
            <div key={index} className="past-bill-card">
              <p><strong>{bill.invoiceNumber}</strong></p>
              <p>{new Date(bill.createdAt).toLocaleString()}</p>
              <p>Total: ₹ {bill.grandTotal}</p>
            </div>
          ))
        )}
      </div>
    </div>
  );
}

export default PastBills;