import React from "react";
import { BrowserRouter as Router, Route, Switch, Link } from "react-router-dom";
import "./App.css";
import Calendar from "./components/Calendar";
import Inventory from "./components/Inventory";
import Orders from "./components/Orders";

const App = () => {
  return (
    <Router>
      <div className="app">
        <header className="app-header">
          <h1 className="app-title">🚗 Serwis Samochodowy</h1>
          <nav>
            <ul className="nav-links">
              <li>
                <Link to="/">Usługi</Link>
              </li>
              <li>
                <Link to="/calendar">Terminarz</Link>
              </li>
              <li>
                <Link to="/inventory">Magazyn</Link>
              </li>
              <li>
                <Link to="/orders">Zamówienia</Link>
              </li>
            </ul>
          </nav>
        </header>
        <main>
          <Switch>
            <Route exact path="/" component={Services} />
            <Route path="/calendar" component={Calendar} />
            <Route path="/inventory" component={Inventory} />
            <Route path="/orders" component={Orders} />
          </Switch>
        </main>
      </div>
    </Router>
  );
};

const Services = () => (
  <div className="services">
    <h2>Nasze Usługi:</h2>
    <p>Wybierz usługę z menu powyżej.</p>
  </div>
);

export default App;
