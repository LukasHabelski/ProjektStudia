import React, { useEffect, useState } from "react";
import "./Inventory.css";

function Inventory() {
  const [products, setProducts] = useState([]);
  const [productName, setProductName] = useState("");
  const [productQuantity, setProductQuantity] = useState("");

  useEffect(() => {
    fetch("/api/Products")
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, []);

  const handleAddProduct = () => {
    const newProduct = { name: productName, quantity: productQuantity };
    fetch("/api/Products", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newProduct),
    })
      .then((response) => response.json())
      .then((data) => setProducts([...products, data]));
  };

  const handleDelete = (id) => {
    fetch(`/api/Products/${id}`, { method: "DELETE" }).then(() =>
      setProducts(products.filter((product) => product.id !== id))
    );
  };

  return (
    <div className="inventory">
      <h2>Magazyn</h2>
      <ul>
        {products.map((product) => (
          <li key={product.id}>
            {product.name} - {product.quantity}
            <button onClick={() => handleDelete(product.id)}>Usuń</button>
          </li>
        ))}
      </ul>
      <h3>Dodaj produkt</h3>
      <input
        type="text"
        placeholder="Nazwa"
        value={productName}
        onChange={(e) => setProductName(e.target.value)}
      />
      <input
        type="number"
        placeholder="Ilość"
        value={productQuantity}
        onChange={(e) => setProductQuantity(e.target.value)}
      />
      <button onClick={handleAddProduct}>Dodaj</button>
    </div>
  );
}

export default Inventory;
