function CatalogList({ catalogType, catalogItems, addToBill }) {
  return (
    <div className="card">
      <h2>{catalogType} Catalog</h2>

      <div className="catalog-grid">
        {catalogItems.length === 0 ? (
          <p>No catalog items found.</p>
        ) : (
          catalogItems.map((item) => (
            <div className="catalog-item" key={item.id}>
              <h3>{item.name}</h3>
              <p>₹ {item.price}</p>
              <p>{item.isVariablePrice ? "Variable Price" : "Fixed Price"}</p>
              <button onClick={() => addToBill(item)}>Add</button>
            </div>
          ))
        )}
      </div>
    </div>
  );
}

export default CatalogList;