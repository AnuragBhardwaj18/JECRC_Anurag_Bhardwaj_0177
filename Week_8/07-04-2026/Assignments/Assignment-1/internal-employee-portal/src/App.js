import React from "react";
import { useAuth } from "./context/AuthContext";
import { useTheme } from "./context/ThemeContext";
import Login from "./components/Login";
import Dashboard from "./components/Dashboard";

function App() {
  // Getting authentication state from AuthContext
  const { isAuthenticated } = useAuth();

  // Getting active theme from ThemeContext
  const { theme } = useTheme();

  return (
    <div className={`app ${theme}`}>
      {/* If logged in show dashboard else show login page */}
      {isAuthenticated ? <Dashboard /> : <Login />}
    </div>
  );
}

export default App;