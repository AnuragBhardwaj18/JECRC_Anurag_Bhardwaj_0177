import { useState } from "react";

function CustomItemForm({ show, onClose, onAddCustomItem }) {
  const [itemName, setItemName] = useState("");
  const [unitPrice, setUnitPrice] = useState("");
  const [quantity, setQuantity] = useState(1);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!itemName.trim()) {
      alert("Please enter item name.");
      return;
    }

    if (Number(unitPrice) < 0 || unitPrice === "") {
      alert("Please enter valid price.");
      return;
    }

    if (Number(quantity) <= 0) {
      alert("Please enter valid quantity.");
      return;
    }

    onAddCustomItem({
      itemName: itemName.trim(),
      unitPrice: Number(unitPrice),
      quantity: Number(quantity)
    });

    setItemName("");
    setUnitPrice("");
    setQuantity(1);
    onClose();
  };

  if (!show) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-box">
        <h2>Add Custom Item</h2>

        <form onSubmit={handleSubmit}>
          <label>Item Name</label>
          <input
            type="text"
            value={itemName}
            onChange={(e) => setItemName(e.target.value)}
            placeholder="Enter custom item name"
          />

          <label>Price</label>
          <input
            type="number"
            min="0"
            value={unitPrice}
            onChange={(e) => setUnitPrice(e.target.value)}
            placeholder="Enter price"
          />

          <label>Quantity</label>
          <input
            type="number"
            min="1"
            value={quantity}
            onChange={(e) => setQuantity(e.target.value)}
          />

          <div className="modal-actions">
            <button type="submit">Add Item</button>
            <button type="button" className="danger" onClick={onClose}>
              Cancel
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default CustomItemForm;