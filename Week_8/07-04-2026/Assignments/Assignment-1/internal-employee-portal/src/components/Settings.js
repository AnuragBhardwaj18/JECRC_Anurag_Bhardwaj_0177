import React from "react";
import { useTheme } from "../context/ThemeContext";

function Settings() {
  // Access current theme from global theme context
  const { theme } = useTheme();

  return (
    <div className="card">
      <h3>Settings</h3>
      <p>
        Current Theme: <strong>{theme}</strong>
      </p>
      <p>This section represents portal settings.</p>
    </div>
  );
}

export default Settings;