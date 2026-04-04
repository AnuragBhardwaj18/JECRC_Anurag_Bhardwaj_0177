function DailySummary({ dailySummary }) {
  return (
    <div className="card">
      <h2>Daily Summary</h2>

      {dailySummary ? (
        <>
          <p><strong>Date:</strong> {dailySummary.date}</p>
          <p><strong>Total Bills:</strong> {dailySummary.totalBills}</p>
          <p><strong>Total Sales:</strong> ₹ {dailySummary.totalSales}</p>
        </>
      ) : (
        <p>No summary available.</p>
      )}
    </div>
  );
}

export default DailySummary;