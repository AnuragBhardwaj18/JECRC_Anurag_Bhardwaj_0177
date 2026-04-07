import React from "react";
import ReactDOM from "react-dom/client";
import "./App.css";
import App from "./App";

// Importing all context providers
import { AuthProvider } from "./context/AuthContext";
import { ThemeProvider } from "./context/ThemeContext";
import { EmployeeProvider } from "./context/EmployeeContext";

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
  <React.StrictMode>
    {/* ThemeProvider manages global theme state */}
    <ThemeProvider>
      {/* AuthProvider manages login/logout and current user */}
      <AuthProvider>
        {/* EmployeeProvider manages employee CRUD data globally */}
        <EmployeeProvider>
          <App />
        </EmployeeProvider>
      </AuthProvider>
    </ThemeProvider>
  </React.StrictMode>
);