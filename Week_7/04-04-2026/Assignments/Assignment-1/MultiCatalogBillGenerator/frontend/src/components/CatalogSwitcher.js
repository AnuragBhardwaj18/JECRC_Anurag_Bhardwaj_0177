function CatalogSwitcher({ setCatalogType, onOpenCustomItemForm }) {
  return (
    <div className="card">
      <h2>Catalog Switch</h2>
      <div className="catalog-buttons">
        <button onClick={() => setCatalogType("EntranceFee")}>Entrance Fee</button>
        <button onClick={() => setCatalogType("Donation")}>Donation</button>
        <button onClick={() => setCatalogType("SellingPrice")}>Selling Price</button>
        <button onClick={onOpenCustomItemForm}>Custom Item</button>
      </div>
    </div>
  );
}

export default CatalogSwitcher;