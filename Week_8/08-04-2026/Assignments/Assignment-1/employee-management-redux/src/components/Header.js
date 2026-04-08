import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { logout } from "../features/auth/authSlice";
import { toggleTheme } from "../features/ui/uiSlice";

function Header() {
  const dispatch = useDispatch();
  const { currentUser } = useSelector((state) => state.auth);
  const { theme } = useSelector((state) => state.ui);

  return (
    <div className="header">
      <div>
        <h2>Employee Management Dashboard</h2>
        <p>Welcome, {currentUser?.username}</p>
      </div>

      <div className="header-actions">
        <button onClick={() => dispatch(toggleTheme())}>
          Switch to {theme === "light" ? "Dark" : "Light"} Theme
        </button>
        <button className="logout-btn" onClick={() => dispatch(logout())}>
          Logout
        </button>
      </div>
    </div>
  );
}

export default Header;