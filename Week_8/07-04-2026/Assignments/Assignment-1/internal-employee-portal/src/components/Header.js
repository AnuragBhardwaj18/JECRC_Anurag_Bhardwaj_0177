import React from "react";
import { useAuth } from "../context/AuthContext";
import { useTheme } from "../context/ThemeContext";

function Header() {
  // Accessing current user and logout from auth context
  const { currentUser, logout } = useAuth();

  // Accessing theme info from theme context
  const { theme, toggleTheme } = useTheme();

  return (
    <header className="header">
      <div>
        <h2>Employee Portal</h2>
        <p className="small-text">
          Welcome, {currentUser?.name} ({currentUser?.role})
        </p>
      </div>

      <div className="header-actions">
        {/* Theme switch button */}
        <button onClick={toggleTheme} className="secondary-btn">
          Switch to {theme === "light" ? "Dark" : "Light"} Mode
        </button>

        {/* Logout button */}
        <button onClick={logout} className="danger-btn">
          Logout
        </button>
      </div>
    </header>
  );
}

export default Header;