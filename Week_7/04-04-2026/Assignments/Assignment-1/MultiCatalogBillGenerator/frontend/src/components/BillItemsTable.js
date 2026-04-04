function BillItemsTable({ billItems, updateItem, removeItem }) {
  return (
    <div className="card">
      <h2>Bill Items</h2>

      {billItems.length === 0 ? (
        <p>No items added yet.</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Item</th>
              <th>Price</th>
              <th>Qty</th>
              <th>Total</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {billItems.map((item) => (
              <tr key={item.id}>
                <td>{item.itemName}</td>

                <td>
                  <input
                    type="number"
                    min="0"
                    value={item.unitPrice}
                    onChange={(e) => updateItem(item.id, "unitPrice", e.target.value)}
                  />
                </td>

                <td>
                  <input
                    type="number"
                    min="1"
                    value={item.quantity}
                    onChange={(e) => updateItem(item.id, "quantity", e.target.value)}
                  />
                </td>

                <td>₹ {Number(item.unitPrice) * Number(item.quantity)}</td>

                <td>
                  <button className="danger" onClick={() => removeItem(item.id)}>
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default BillItemsTable;