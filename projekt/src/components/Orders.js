import React, { useEffect, useState } from "react";
import "./Orders.css";

function Orders() {
  const [orders, setOrders] = useState([]);
  const [description, setDescription] = useState("");
  const [totalCost, setTotalCost] = useState("");

  useEffect(() => {
    fetch("/api/Orders")
      .then((response) => response.json())
      .then((data) => setOrders(data));
  }, []);

  const handleAddOrder = () => {
    const newOrder = { description, totalCost };
    fetch("/api/Orders", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newOrder),
    })
      .then((response) => response.json())
      .then((data) => setOrders([...orders, data]));
  };

  const handleDelete = (id) => {
    fetch(`/api/Orders/${id}`, { method: "DELETE" }).then(() =>
      setOrders(orders.filter((order) => order.id !== id))
    );
  };

  return (
    <div className="orders">
      <h2>Zamówienia</h2>
      <ul>
        {orders.map((order) => (
          <li key={order.id}>
            {order.description} - {order.totalCost}
            <button onClick={() => handleDelete(order.id)}>Usuń</button>
          </li>
        ))}
      </ul>
      <h3>Dodaj zamówienie</h3>
      <input
        type="text"
        placeholder="Opis"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
      />
      <input
        type="number"
        placeholder="Koszt"
        value={totalCost}
        onChange={(e) => setTotalCost(e.target.value)}
      />
      <button onClick={handleAddOrder}>Dodaj</button>
    </div>
  );
}

export default Orders;
