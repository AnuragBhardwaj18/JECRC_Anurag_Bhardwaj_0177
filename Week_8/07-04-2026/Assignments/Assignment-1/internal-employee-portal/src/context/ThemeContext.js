import React, { createContext, useContext, useEffect, useMemo, useState } from "react";

// Creating ThemeContext for light/dark theme management
const ThemeContext = createContext();

export const ThemeProvider = ({ children }) => {
  // theme stores current active theme
  const [theme, setTheme] = useState("light");

  // toggleTheme switches between light and dark themes
  const toggleTheme = () => {
    setTheme((prev) => (prev === "light" ? "dark" : "light"));
  };

  // Updating body class whenever theme changes
  useEffect(() => {
    document.body.className = theme;
  }, [theme]);

  // Memoized context value for performance optimization
  const value = useMemo(() => {
    return { theme, toggleTheme };
  }, [theme]);

  return <ThemeContext.Provider value={value}>{children}</ThemeContext.Provider>;
};

// Custom hook for ThemeContext
export const useTheme = () => useContext(ThemeContext);