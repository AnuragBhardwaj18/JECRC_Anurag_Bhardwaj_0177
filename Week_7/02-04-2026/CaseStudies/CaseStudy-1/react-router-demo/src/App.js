import React from "react";
import { BrowserRouter, Routes, Route, NavLink } from "react-router-dom";

import Home from "./pages/home";
import About from "./pages/about";
import Contact from "./pages/contact";

function App() {
  return (
    <BrowserRouter>
      
      {/* Navbar */}
      <nav style={styles.nav}>
        <NavLink to="/" style={styles.link} end>
          Home
        </NavLink>

        <NavLink to="/about" style={styles.link}>
          About
        </NavLink>

        <NavLink to="/contact" style={styles.link}>
          Contact
        </NavLink>
      </nav>

      {/* Routes */}
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
      </Routes>

    </BrowserRouter>
  );
}

const styles = {
    nav: {
        display: 'flex',
        gap: '20px',
        padding: '15px',
        background: '#2e2c2c',
        justifyContent: 'center'
    },
    link: ({ isActive }) => ({
        textDecoration: 'none',
        color: isActive ? '#dbbc7a' : 'white',
        fontWeight: isActive ? 'bold' : 'normal'
    })
};

export default App;