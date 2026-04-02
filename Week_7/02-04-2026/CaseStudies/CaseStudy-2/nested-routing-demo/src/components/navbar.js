import React from "react";
import { NavLink } from "react-router-dom";

function Navbar() {

  return (
    <nav style={styles.nav}>
      
      <h2 style={styles.logo}>MyApp</h2>

      <div>
        <NavLink to="/" style={styles.link} end>
          Home
        </NavLink>

        <NavLink to="/about" style={styles.link}>
          About
        </NavLink>

        <NavLink to="/contact" style={styles.link}>
          Contact
        </NavLink>
      </div>

    </nav>
  );
}

const styles = {
  nav: {
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    padding: "15px 30px",
    background: "#333"
  },
  logo: {
    color: "white",
    margin: 0
  },
  link: ({isActive}) => ({
    margin: "0 10px",
    textDecoration: "none",
    color: isActive ? "yellow" : "white",
    fontWeight: isActive ? "bold" : "normal"
  })
};

export default Navbar;